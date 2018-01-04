using OnlineCarrerPortal.DataLayer;
using OnlineCarrerPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCarrerPortal.Service
{
    public class JobService
    {
        public static List<JobModel> SearchJobs(string title, string qualification)
        {
            return new JobDetails().SearchJobs(title, qualification);
        }
        public static bool ApplyThisJob(int JobID, int UserID, int EmployerID)
        {
            return new JobDetails().ApplyThisJob(JobID, UserID, EmployerID);
        }
        public static JobModel InsertJob(JobModel JobDetails)
        {
            return new JobDetails().InsertJobDetails(JobDetails);
        }
        public static bool InsertInterviewCalls(InterviewModel InterviewDetails)
        {
            return new JobDetails().InsertInterviewCalls(InterviewDetails);
        }
        public static List<JobModel> GetAppliedJobs(int EmployerID)
        {
            return new JobDetails().GetAppliedJobs(EmployerID);
        }
    }
}
