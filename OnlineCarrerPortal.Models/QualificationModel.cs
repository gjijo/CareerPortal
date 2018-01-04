using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCarrerPortal.Models
{
    public class QualificationModel
    {
        /// <summary>
        /// QualificationID
        /// </summary>
        public long UserID { get; set; }
        public long QualificationID { get; set; }

        /// <summary>
        /// Qualification
        /// </summary>
        public string Qualification { get; set; }
    }
}
