using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserManagementUI.Models;

namespace UserManagementUI.Controllers
{
    public class CertificationsController : Controller
    {
        public async Task<IActionResult> AllCertificatios()
        {
            List<Certifications> Certificationslist;
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync("https://localhost:44309/api/Certifications/AllCertifications"))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    Certificationslist = JsonConvert.DeserializeObject<List<Certifications>>(apiresponse);
                }

            }
            return View(Certificationslist);
        }
        public IActionResult CreateCertification()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCertification(Certifications model)
        {
            using (var httpclient = new HttpClient())
            {
                StringContent content = new StringContent
                    (JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await httpclient.PostAsync("https://localhost:44309/api/Certifications/AddCertification", content))
                { };
            }
            return RedirectToAction("AllCertificatios");
        }
    }
}
