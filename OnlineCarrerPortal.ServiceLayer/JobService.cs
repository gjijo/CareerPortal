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
        public static bool InsertJob(JobModel JobDetails)
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
        public static List<JobModel> GetAppliedJobOfSeeker(int EmployerID)
        {
            return new JobDetails().GetAppliedJobOfSeeker(EmployerID);
        }
        public static List<InterviewModel> GetScheduledInterviewOfSeeker(int UserID)
        {
            return new JobDetails().GetScheduledInterviewOfSeeker(UserID);
        }
    }
}
