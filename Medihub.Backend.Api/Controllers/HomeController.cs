﻿using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Medihub.Backend.Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
             LogManager.GetCurrentClassLogger().Debug("test");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}