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
    }
}
