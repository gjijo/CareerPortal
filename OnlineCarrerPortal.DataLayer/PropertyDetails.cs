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

namespace OnlineCarrerPortal.DataLayer
{
    public class PropertyDetails : Entity
    {
        public PropertyDetails(IDbConnection Connection)
        {
            base.Connection = Connection;
        }
        public PropertyDetails(IDbTransaction Transaction)
        {
            base.Transaction = Transaction;
        }

        public UserModel GetUserLoginDetails(string userName, string password)
        {
            DynamicParameters parms = new DynamicParameters();
            parms.Add("@UserName", userName);
            parms.Add("@Password", password);
            return new DapperRepository<UserModel>().FindByID("SelectUserLogin", parms);
        }
        public bool InsertUserDetails(UserModel UserDetails)
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
            parms.Add("@Qalification", UserDetails.Qalification);
            parms.Add("@ContactNumber", UserDetails.ContactNumber);
            return  new DapperRepository<UserModel>().Add("InsertUserDetails", parms);                                                                                    
        }
    }
}
