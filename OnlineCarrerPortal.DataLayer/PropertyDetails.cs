#region Included Namespaces
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using OnlineCarrerPortal.Models;
using System.Data.Common;
using Dapper; 
#endregion

namespace OnlineCarrerPortal.DataLayer
{
    public class PropertyDetails
    {
        #region GetUserLoginDetails
        /// <summary>
        /// GetUserLoginDetails
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserModel GetUserLoginDetails(string userName, string password)
        {
            DynamicParameters parms = new DynamicParameters();
            parms.Add("@UserName", userName);
            parms.Add("@Password", password);
            return new DapperRepository<UserModel>().FindByID("SelectUserLogin", parms);
        } 
        #endregion

        #region InsertUserDetails
        /// <summary>
        /// InsertUserDetails
        /// </summary>
        /// <param name="UserDetails"></param>
        /// <returns></returns>
        public UserModel InsertUserDetails(UserModel UserDetails)
        {
            DynamicParameters parms = new DynamicParameters();
            parms.Add("@UserID", UserDetails.UserID);
            parms.Add("@FirstName", UserDetails.FirstName);
            parms.Add("@LastName", UserDetails.LastName);
            parms.Add("@Email", UserDetails.Email);
            parms.Add("@UserTypeID", UserDetails.UserTypeID);
            parms.Add("@Password", UserDetails.Password);
            parms.Add("@IsRegistrationApproved", UserDetails.IsRegistrationApproved);
            parms.Add("@IsDeleted", UserDetails.IsDeleted);
            parms.Add("@Qalification", "");
            parms.Add("@ContactNumber", UserDetails.ContactNumber);
            return new DapperRepository<UserModel>().FindByID("InsertUserDetails", parms);
        } 
        #endregion

        #region GetAllQualification
        /// <summary>
        /// GetAllQualification
        /// </summary>
        /// <returns></returns>
        public List<QualificationModel> GetAllQualification()
        {
            DynamicParameters parms = new DynamicParameters();
            return new DapperRepository<QualificationModel>().SelectQuery("SelectAllQualification", parms);
        } 
        #endregion

        #region InsertUserQualificationReln
        /// <summary>
        /// InsertUserQualificationReln
        /// </summary>
        /// <param name="QM"></param>
        /// <returns></returns>
        public bool InsertUserQualificationReln(QualificationModel QM)
        {
            DynamicParameters parms = new DynamicParameters();
            parms.Add("@UserID", QM.UserID);
            parms.Add("@QualificationID", QM.QualificationID);
            return new DapperRepository<QualificationModel>().Add("InsertUserQualificationReln", parms);
        } 
        #endregion
    }
}
