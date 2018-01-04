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
    public class JobDetails
    {
        #region GetAppliedJobs
        /// <summary>
        /// GetAppliedJobs
        /// </summary>
        /// <param name="EmployerID"></param>
        /// <returns></returns>
        public List<JobModel> GetAppliedJobs(int EmployerID)
        {
            DynamicParameters parms = new DynamicParameters();
            parms.Add("@EmployerID", EmployerID);
            return new DapperRepository<JobModel>().SelectQuery("SelectAppliedJobsFOrScheduling", parms);
        }
        #endregion

        #region InsertJobDetails
        /// <summary>
        /// InsertJobDetails
        /// </summary>
        /// <param name="JobDetails"></param>
        /// <returns></returns>
        public bool InsertJobDetails(JobModel JobDetails)
        {
            DynamicParameters parms = new DynamicParameters();
            parms.Add("@JobTitle", JobDetails.JobTitle);
            parms.Add("@Description", JobDetails.Description);
            parms.Add("@PostedDate", DateTime.Now);
            parms.Add("@EmployerID", JobDetails.EmployerID);
            parms.Add("@CompanyName", JobDetails.CompanyName);
            parms.Add("@SalaryPackage", JobDetails.SalaryPackage);
            parms.Add("@IsDeleted", JobDetails.IsDeleted);
            parms.Add("@RequiredQalification", JobDetails.RequiredQalification);
            parms.Add("@EndDate", DateTime.Now);
            parms.Add("@ContactNumber", JobDetails.ContactNumber);
            return new DapperRepository<JobModel>().Add("InsertJobs", parms);
        }
        public bool InsertInterviewCalls(InterviewModel InterviewDetails)
        {
            DynamicParameters parms = new DynamicParameters();
            parms.Add("@AppliedJobID", InterviewDetails.AppliedJobID);
            parms.Add("@InterviewDate", InterviewDetails.InterviewDate);
            parms.Add("@Venue", InterviewDetails.Venue);
            parms.Add("@Description", InterviewDetails.Description);
            parms.Add("@Status", InterviewDetails.Status);
            return new DapperRepository<JobModel>().Add("InsertInterviewCalls", parms);
        }
        #endregion
    }

}
