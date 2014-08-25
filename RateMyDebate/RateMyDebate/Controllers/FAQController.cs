using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RateMyDebate.Controllers
{
    public class FAQController : Controller
    {
        //
        // GET: /FAQ/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult WhatIsRateMyDebate()
        {
            return View();
        }

	}
}