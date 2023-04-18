using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace FileUploadTest.Repositories
{
    public class DatabaseRepository
    {
        private readonly string connectionString;
        private readonly string[] AllowedFileExtensions = { ".jpg", ".jpeg", ".png", ".pdf" };
        private readonly int maxFileSize = 2 * 1024 * 1024;

        public DatabaseRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        }
        public bool CheckFileSizeUnder2MB(int contentLength)
        {
            if (contentLength > maxFileSize)
            {
                return false;
            }
            return true;
        }
        public string SaveImage(HttpPostedFileBase logoFile)
        {
            if (!AllowedFileExtensions.Contains(logoFile.ContentType))
            {
                return null;
            }

            byte[] fileContent;

            try
            {
                using (var binaryReader = new BinaryReader(logoFile.InputStream))
                {
                    fileContent = binaryReader.ReadBytes(logoFile.ContentLength);
                }

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("dbo.InsertUploadedFile", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@FileName", Path.GetFileName(logoFile.FileName));
                        command.Parameters.AddWithValue("@FileContent", fileContent);
                        command.Parameters.AddWithValue("@ContentType", logoFile.ContentType);
                        command.ExecuteNonQuery();
                    }
                }

                return GetLastImage();
            } 
            catch
            {
                return null;
            }
        }
        public string GetLastImage()
        {
            byte[] fileContent;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT TOP 1 FileContent FROM UploadedFiles ORDER BY Id DESC", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            fileContent = (byte[])reader["FileContent"];
                            return Convert.ToBase64String(fileContent);
                        }
                    }
                }
            }
            return null;
        }
    }
}