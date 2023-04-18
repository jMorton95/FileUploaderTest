using FileUploadTest.Models;
using FileUploadTest.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileUploadTest.Repositories;

namespace FileUploadTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly FrontEndService _frontEndService = new FrontEndService();
        private readonly DatabaseRepository _databaseRepository = new DatabaseRepository();
       
        public ActionResult Index() 
        {
            OrderFormModel model = new OrderFormModel(_frontEndService);
            model.Image = _databaseRepository.GetLastImage();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(OrderFormModel model)
        {
            if (model.FrontEndDataModel == null)
            {
                model.FrontEndDataModel = _frontEndService.GenerateFrontEndData();
            }

            if (!_databaseRepository.CheckFileSizeUnder2MB(model.LogoFile.ContentLength))
            {
                ModelState.AddModelError("file", "File exceeds 2MB");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                OrderSanitisationService _orderSanitisationService = new OrderSanitisationService();
                _orderSanitisationService.SanitiseOrder(model);

                model.Image = _databaseRepository.SaveImage(model.LogoFile);
               
                //return View("Basket");
            }

            
            return View(model);
        }
        
    }
}