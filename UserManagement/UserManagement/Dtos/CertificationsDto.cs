using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementWithUOW.Core.Models;

namespace UserManagementAPI.Dtos
{
    public class CertificationsDto
    {
        public int CertificationsId { get; set; }
        public string Title { get; set; }
        public ICollection<User> users { get; set; }
        public List<UsersCretifications> UsersCretifications { get; set; }
    }
}
