using FileUploadTest.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FileUploadTest.Models
{
    public class OrderFormModel
    {
        public OrderFormModel()
        {

        }
        public OrderFormModel(FrontEndService frontEndService)
        {
            FrontEndDataModel = frontEndService.GenerateFrontEndData();
        }
        [Required]
        public int Quantity { get; set; }
        public ServiceOptions ServiceOptions { get; set; }
        public OrientationOptions OrientationOptions { get; set; }
        public TemplateOptions TemplateOptions { get; set; }
        public PrintOnReverseOptions PrintOnReverseOptions { get; set; }
        public MagStripeEncodingOptions MagStripeEncodingOptions { get; set; }
        public HttpPostedFileBase LogoFile { get; set; }
        public List<FrontEndDataModel> FrontEndDataModel { get; set; }
        public string Image { get; set; }
    }

}