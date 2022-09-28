using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementAPI.Dtos;
using UserManagementWithUOW.Core;
using UserManagementWithUOW.Core.Models;
using UserManagementWithUOW.EF;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CertificationsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CertificationsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult AllCertifications()
        {
            var certifications = _unitOfWork.Certifications.GetAll();
            var result = _mapper.Map<IEnumerable<CertificationsDto>>(certifications);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddCertification(CertificationsDto certificationdto)
        {
            var certification = _mapper.Map<Certifications>(certificationdto);
            var newCertification = _unitOfWork.Certifications.Add(certification);
            _unitOfWork.Complete();
            return Ok(newCertification);
        }
        [HttpGet]
        public IActionResult GetCertificationsofUser(int userid)
        {
            var usercertifications = _unitOfWork.userscretifications.GetAll(a => a.UserId == userid).Select(a => a.CertificationsId);

            var othercertifications = _unitOfWork.Certifications.GetAll(a => !usercertifications.Contains(a.CertificationsId));
            return Ok(othercertifications);
        }
    }
}
