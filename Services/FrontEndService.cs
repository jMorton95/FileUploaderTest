using FileUploadTest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FileUploadTest.Services
{
    public class FrontEndService
    {
        
        public List<FrontEndDataModel> GenerateFrontEndData()
        {
            return new List<FrontEndDataModel>()
            {
                new FrontEndDataModel()
                {
                    QuantityCap = 24,
                    FixedQuantity = 10,
                    PricePerCard = 5.50M,
                    CardPackPrice = 55.00M
                },
                new FrontEndDataModel()
                {
                    QuantityCap = 49,
                    FixedQuantity = 25,
                    PricePerCard = 4.95M,
                    CardPackPrice = 123.75M
                },
                new FrontEndDataModel()
                {
                    QuantityCap = 99,
                    FixedQuantity = 50,
                    PricePerCard = 4.50M,
                    CardPackPrice = 225.00M,

                },
                new FrontEndDataModel()
                {
                    QuantityCap = 100,
                    FixedQuantity = 100,
                    PricePerCard = 3.95M,
                    CardPackPrice = 395.00M,
                }
            };
        }
    }
}