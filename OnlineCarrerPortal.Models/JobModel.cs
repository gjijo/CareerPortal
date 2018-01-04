using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCarrerPortal.Models
{
    public class JobModel
    {
        public int JobID { get; set; }
        public int UserID { get; set; }
        public DateTime AppliedDate { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public string PostedDate { get; set; }
        public int EmployerID { get; set; }
        public string CompanyName { get; set; }
        public string SalaryPackage { get; set; }
        public string IsDeleted { get; set; }
        public string RequiredQalification { get; set; }
        public string EndDate { get; set; }
        public string ContactNumber { get; set; }
        public string EmployerName { get; set; }
        public string SeekerName { get; set; }
        public bool IsInterviewScheduled { get; set; }

        /// <summary>
        /// Qualification
        /// </summary>
        public List<string> Qualification { get; set; }
    }
}
