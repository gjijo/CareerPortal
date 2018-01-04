using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCarrerPortal.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int UserTypeID { get; set; }
        public string Password { get; set; }
        public string IsRegistrationApproved { get; set; }
        public string IsDeleted { get; set; }
        public List<string> Qalification { get; set; }
        public string Experience { get; set; }
        public string VPath { get; set; }
        public string ContactNumber { get; set; }
    }
}
