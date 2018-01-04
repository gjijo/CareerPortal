using OnlineCarrerPortal.DataLayer;
using OnlineCarrerPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCarrerPortal.Service
{
    public class UserService
    {
        public static int InsertUser(UserModel RegisterDetails)
        {
            using (DALHelper helper = new DALHelper())
            {
                helper.OpenConnectionWithTransaction();

                helper.GetDAL_PropertyDetails(false).InsertUserDetails(RegisterDetails);

                helper.EndConnectionAndCommitTransaction();
            }
            return 1;
        }

        public static UserModel GetUserLoginDetails(UserModel objModel)
        {
            using (DALHelper helper = new DALHelper())
            {
                return helper.GetDAL_PropertyDetails(false).GetUserLoginDetails(objModel.Email,objModel.Password);
            }
        }
    }
}
