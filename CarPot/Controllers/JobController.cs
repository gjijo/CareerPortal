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
        public int UserID
        {
            get
            {
                if (Session["User"] != null)
                {
                    return (Session["User"] as UserModel).UserID;
                }
                else
                {
                    return 0;
                }
            }
        }
        public ActionResult Index()
        {
            List<QualificationModel> objModel = new List<QualificationModel>();
            objModel = UserService.GetAllQualification();
            return View(objModel);
        }
        public ActionResult AppliedJobsEmployer()
        {
            List<JobModel> lsModel = JobService.GetAppliedJobs(UserID);
            return View(lsModel);
        }
        public ActionResult AppliedJobsSeeker()
        {
            List<JobModel> lsModel = JobService.GetAppliedJobOfSeeker(UserID);
            return View(lsModel);
        }
        public ActionResult ScheduledJobsSeeker()
        {
            List<InterviewModel> lsModel = JobService.GetScheduledInterviewOfSeeker(UserID);
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
            QualificationModel QM = new QualificationModel();
            JobModel job = JobService.InsertJob(objMOdel);
            foreach (string s in objMOdel.Qualification)
            {
                QM.JobID = job.JobID;
                QM.QualificationID = long.Parse(s);
                UserService.InsertUserQualificationReln(QM);
            }
            return View();
        }

        public ActionResult SearchJob()
        {
            List<QualificationModel> objModel = new List<QualificationModel>();
            objModel = UserService.GetAllQualification();
            return View(objModel);
        }

        public JsonResult GetAvailableJobs(string JobTitle, string JobType)
        {            
            return Json(JobService.SearchJobs(JobTitle, JobType), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ApplyThisJob(int JobID, int EmployerID)
        {
            return Json(JobService.ApplyThisJob(JobID, 1, EmployerID), JsonRequestBehavior.AllowGet);
        }
    }
}