using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileUploadTest.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
        public string ContentType { get; set; }
    }
}