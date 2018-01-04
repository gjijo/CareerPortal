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
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if (Session["User"] != null)
            {
                return View(@"~\Views\Home\Index.cshtml");
            }
            else
            {
                List<QualificationModel> objModel = new List<QualificationModel>();
                objModel = UserService.GetAllQualification();
                return View(objModel);
            }
        }

        #region Registration
        /// <summary>
        /// Registration
        /// </summary>
        /// <returns></returns>
        public ActionResult Registration()
        {
            return View();
        } 
        #endregion

        #region Registration - Post
        /// <summary>
        /// Registration
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Registration(UserModel objModel)
        {
            QualificationModel QM = new QualificationModel();
            UserModel User = UserService.InsertUser(objModel);
            foreach(string s in objModel.Qalification)
            {                
                QM.UserID = User.UserID;
                QM.QualificationID = long.Parse(s);
                UserService.InsertUserQualificationReln(QM);
            }
                        
            List<QualificationModel> objModelQ = new List<QualificationModel>();
            objModelQ = UserService.GetAllQualification();
            return View(@"~\Views\Login\Index.cshtml", objModelQ);
        } 
        #endregion

        #region CreateCV
        /// <summary>
        /// expertID
        /// </summary>
        /// <returns></returns>
        public JsonResult CreateCV()
        {
            string fileName = "";
            if (Request.Files.Count > 0)
            {

                string TempFileName;
                HttpFileCollectionBase files = Request.Files;
                HttpPostedFileBase file = files[0];

                if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                {
                    string[] tempFile = file.FileName.Split(new char[] { '\\' });
                    fileName = DateTime.Now.Ticks + "_" + tempFile[tempFile.Length - 1];
                    TempFileName = DateTime.Now.Ticks + "_" + tempFile[tempFile.Length - 1];
                }
                else
                {
                    fileName = DateTime.Now.Ticks + "_" + file.FileName;
                    TempFileName = DateTime.Now.Ticks + "_" + file.FileName;
                }

                file.SaveAs(Path.Combine(Server.MapPath("/CV/"), fileName));

            }


            return Json(new { Status = fileName }, JsonRequestBehavior.AllowGet);
        }
        #endregion CreateCV

        #region Login - Post
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(UserModel objModel)
        {
            UserModel LoginDetails = UserService.GetUserLoginDetails(objModel);
            if (LoginDetails != null)
            {
                Session["User"] = LoginDetails;
                return View(@"~\Views\Home\Index.cshtml");
            }
            else
            {
                return RedirectToAction("Index");
            }
        } 
        #endregion

        public ActionResult LogOut()
        {
            Session["User"] = null;
            return RedirectToAction("index");
        }
    }
}