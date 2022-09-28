using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagementWithUOW.Core.Models
{
   public class UsersCretifications
    {
        public int UserId { get; set; }
        public int CertificationsId { get; set; }
        public User users { get; set; }
        public Certifications Certifications { get; set; }
    }
}
