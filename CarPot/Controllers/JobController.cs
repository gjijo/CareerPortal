using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCarrerPortal.Models;
using OnlineCarrerPortal.Service;
using System.IO;

namespace CarPot.Controllers
{
    public class JobController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddJob(JobModel objMOdel)
        {
            JobService.InsertJob(objMOdel);   
            return View();
        }
    }
}