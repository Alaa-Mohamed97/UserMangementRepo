using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementWithUOW.Core.Models;

namespace UserManagementAPI.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public ICollection<Certifications> Certifications { get; set; }
        public List<UsersCretifications> UsersCretifications { get; set; }
    }
}
