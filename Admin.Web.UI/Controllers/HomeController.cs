﻿using System.Web.Mvc;

namespace Admin.Web.UI.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Error()
        {

            return View();
        }
    }
}