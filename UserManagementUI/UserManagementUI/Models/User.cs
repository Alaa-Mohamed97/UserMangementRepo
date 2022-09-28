using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementUI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public ICollection<Certifications> Certifications { get; set; }
        public List<UsersCretifications> UsersCretifications { get; set; }
    }
}
