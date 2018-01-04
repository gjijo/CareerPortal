using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCarrerPortal.Models
{
    public class InterviewModel
    {
        public int InterviewID { get; set; }
        public int AppliedJobID { get; set; }
        public DateTime InterviewDate { get; set; }
        public string Venue { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string EmployerName { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public bool IsPastJob { get; set; }
    }
}
