using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileUploadTest.Models
{
    public class FrontEndDataModel
    {
        public int QuantityCap { get; set; }
        public int FixedQuantity { get; set; }
        public decimal PricePerCard { get; set; }
        public decimal CardPackPrice { get; set; }
    }
}