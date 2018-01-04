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
    public class JobDetails : Entity
    {
        public List<InterviewModel> GetAppliedJobs(int EmployerID)
        {
            DynamicParameters parms = new DynamicParameters();
            parms.Add("@EmployerID", EmployerID);
            return new DapperRepository<InterviewModel>().SelectQuery("SelectAppliedJobsFOrScheduling", parms);
        }
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
    }
    
}
