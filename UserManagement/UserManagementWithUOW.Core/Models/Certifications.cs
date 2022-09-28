using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagementWithUOW.Core.Models
{
    public class Certifications
    {
        public int CertificationsId { get; set; }
        public string Title { get; set; }
        public ICollection<User> users { get; set; }
        public List<UsersCretifications> UsersCretifications { get; set; }

    }
}
