using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementAPI.Dtos;
using UserManagementWithUOW.Core;
using UserManagementWithUOW.Core.Models;
using UserManagementWithUOW.Core.Repositories;
using UserManagementWithUOW.EF;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Alluser()
        {
            var allusers = _unitOfWork.users.GetAll();
            var result = _mapper.Map<IEnumerable<UserDto>>(allusers);
            return Ok(result);
        }
    
        [HttpPost]
        public IActionResult Adduser(UserDto userdto)
        {
            var user = _mapper.Map<User>(userdto);
            var newuser = _unitOfWork.users.Add(user);
            _unitOfWork.Complete();
            return Ok(newuser);
        }
        [HttpGet]
        public IActionResult getuserCertifications()
        {
            var getusers= _unitOfWork.users.GetAll(a => a.Certifications.Count > 5);
            var result = _mapper.Map<IEnumerable<UserDto>>(getusers);
            return Ok(getusers);
        }
        [HttpPost]
        public IActionResult AdduserCertification(UsersCretificationsDto model)
        {
            var userandcertification = _mapper.Map<UsersCretifications>(model);
            var adduserandcertification = _unitOfWork.userscretifications.Add(userandcertification);
            _unitOfWork.Complete();
            return Ok(adduserandcertification);
        }
    }
}
