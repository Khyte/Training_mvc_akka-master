﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingMVC.DATA;

namespace TrainingMVC.Controllers
{
    public class AccueilController : Controller
    {
        // GET: Accueil

        public ActionResult Index()
        {

            return View();
        }


    }
}