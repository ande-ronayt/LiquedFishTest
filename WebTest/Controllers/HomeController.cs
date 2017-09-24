using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebTest.Domain.Infrastracture;
using WebTest.Models;

namespace WebTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult QuestionOne()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(RequestModel req)
        {
            var builder = new FishServiceBuilder { Type = req.ServiceType };
            switch (req.ServiceType)
            {
                case FishServiceType.FROM_URL:
                    builder.Url = req.Url;
                    break;
                case FishServiceType.UPLOAD_FILE:
                    builder.File = req.File;
                    break;
            }

            var fishService = builder.Create();
            try
            {
                var result = fishService.GetTop20();

                return View("Index2", result);
            }
            catch(Exception e)
            {
                TempData.Add("Error", "Error: " + e.Message);
                return View();
            }
        }
    }
}