using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagementWithUOW.Core.Models
{
   public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public ICollection<Certifications> Certifications { get; set; }
        public List<UsersCretifications> UsersCretifications { get; set; }
    }
}
