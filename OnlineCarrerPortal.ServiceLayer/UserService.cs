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
        public static UserModel InsertUser(UserModel RegisterDetails)
        {
            return new PropertyDetails().InsertUserDetails(RegisterDetails);
        }

        public static UserModel GetUserLoginDetails(UserModel objModel)
        {
            return new PropertyDetails().GetUserLoginDetails(objModel.Email, objModel.Password);
        }

        public static List<QualificationModel> GetAllQualification()
        {
            return new PropertyDetails().GetAllQualification();
        }

        public static bool InsertUserQualificationReln(QualificationModel qualificationModel)
        {
            return new PropertyDetails().InsertUserQualificationReln(qualificationModel);
        }
    }
}
