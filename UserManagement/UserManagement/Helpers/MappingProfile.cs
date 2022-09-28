using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementAPI.Dtos;
using UserManagementWithUOW.Core.Models;

namespace UserManagementAPI.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Certifications, CertificationsDto>().ReverseMap();
            CreateMap<UsersCretifications, UsersCretificationsDto>().ReverseMap();
            
        }
    }
}
