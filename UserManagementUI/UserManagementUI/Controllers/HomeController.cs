using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UserManagementUI.Models;
using Newtonsoft.Json;
using System.Text;

namespace UserManagementUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<User> userslist = new List<User>();
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync("https://localhost:44309/api/user/getuserCertifications"))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    userslist = JsonConvert.DeserializeObject<List<User>>(apiresponse);
                }

            }
            return View(userslist);

        }
        public async Task<IActionResult> Allusers()
        {
            List<User> user;
            using (var httpclient = new HttpClient())
            {
                using (var reponse = await httpclient.GetAsync("https://localhost:44309/api/user/Alluser"))
                {
                    string apirespone = await reponse.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<List<User>>(apirespone);
                }
            }
            return View(user);
        }
        public IActionResult Createuser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Createuser(User model)
        {
            using (var httpclient = new HttpClient())
            {
                StringContent content = new StringContent
                    (JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await httpclient.PostAsync("https://localhost:44309/api/user/Adduser", content))
                { };
            }
            return RedirectToAction("Allusers");
        }
        [HttpGet]
        public async Task<IActionResult> AddcertificationToUser()
        {
            List<User> user;
            
            using (var httpclient = new HttpClient())
            {
                using (var reponse = await httpclient.GetAsync("https://localhost:44309/api/user/Alluser"))
                {
                    string apirespone = await reponse.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<List<User>>(apirespone);
                }
               
            }
            ViewBag.users = user;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddcertificatToUser(UsersCretifications model)
        {
            using (var httpclient = new HttpClient())
            {
                StringContent content = new StringContent(
                    JsonConvert.SerializeObject(model), Encoding.UTF8, ("application/json"));
                using (var response = await httpclient.PostAsync("https://localhost:44309/api/user/AdduserCertification", content)) { };
            }
            return RedirectToAction("AddcertificationToUser");
        }
        public async Task<JsonResult> GetAvailableCertification(int userid)
        {
            List<Certifications> Certifications;
            using (var httpclient = new HttpClient())
            {
                using (var reponse = await httpclient.GetAsync("https://localhost:44309/api/Certifications/GetCertificationsofUser?userid="+userid))
                {
                    string apirespone = await reponse.Content.ReadAsStringAsync();
                    Certifications = JsonConvert.DeserializeObject<List<Certifications>>(apirespone);
                }
            }
            return Json(Certifications);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
