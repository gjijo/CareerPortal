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
        public ActionResult AppliedJobsEmployer()
        {
            List<JobModel> lsModel = JobService.GetAppliedJobs(1);
            return View(lsModel);
        }
        public ActionResult ScheduleInterview(int JobID)
        {
            InterviewModel IV = new InterviewModel();
            IV.AppliedJobID = JobID;
            return View(IV);
        }

        [HttpPost]
        public ActionResult ScheduleInterview(InterviewModel Model)
        {
            JobService.InsertInterviewCalls(Model);
            return RedirectToAction("AppliedJobsEmployer");
        }

        [HttpPost]
        public ActionResult AddJob(JobModel objMOdel)
        {
            JobService.InsertJob(objMOdel);   
            return View();
        }

        public ActionResult SearchJob()
        {
            return View();
        }
    }
}