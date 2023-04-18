using FileUploadTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileUploadTest.Services
{
    public class OrderSanitisationService
    {
        public OrderFormModel SanitiseOrder(OrderFormModel model)
        {
            if (model.ServiceOptions == ServiceOptions.Bespoke)
            {
                model.OrientationOptions = OrientationOptions.None;
                model.TemplateOptions = TemplateOptions.None;
            }

            if (model.ServiceOptions == ServiceOptions.Professional)
            {
                model.PrintOnReverseOptions = PrintOnReverseOptions.None;
            }

            return model;
        }
    }
}