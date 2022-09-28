using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementWithUOW.Core.Models;

namespace UserManagementAPI.Dtos
{
    public class UsersCretificationsDto
    {
        public int UserId { get; set; }
        public int CertificationsId { get; set; }
        public User users { get; set; }
        public Certifications Certifications { get; set; }
    }
}
