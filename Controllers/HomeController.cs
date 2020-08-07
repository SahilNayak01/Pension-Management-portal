using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pension_Management_Portal.Models;

namespace Pension_Management_Portal.Controllers
{
    public class HomeController : Controller
    {
        static string token;
        PensionDetail penDetailObj = new PensionDetail();
        private readonly DataContext _context;
        private IConfiguration configuration;
        /// <summary>
        /// Dependency Injection
        /// </summary>
        public HomeController(DataContext context, IConfiguration iConfig)
        {
            _context = context;
            configuration = iConfig;

        }
        /// <summary>
        /// Redirection to login page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// Getting the token a Validating the User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(User user)
        {
            string tokenValue = configuration.GetValue<string>("MyLinkValue:tokenUri");
            token = GetToken(tokenValue, user);
            if (token=="abcd")
            {
                ViewBag.loginerror = "Error Occured";
                return View();
            }
            if (token != null)
            {
                return RedirectToAction("PensionerValues");
            }
            else
            {
                ViewBag.invalid = "UserName or Password invalid";
                return View();
            }
        }
        static string GetToken(string url, User user)
        {
            string token = "abcd";
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                using (var client = new HttpClient())
                {
                    var response = client.PostAsync(url, data).Result;
                    string name = response.Content.ReadAsStringAsync().Result;
                    dynamic details = JObject.Parse(name);
                    return details.token;
                }
            }
            catch(Exception e)
            {
                return token;
            }
        }

        /// <summary>
        /// Getting the values of the Pensioner
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult PensionerValues()
        {

            return View();
        }

        /// <summary>
        /// Validaing the values of the Pensioner
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PensionerValues(PensionerInput input)
        {

            // string status;
            string processValue = configuration.GetValue<string>("MyLinkValue:processUri");

            if (ModelState.IsValid)
            {

                using (var client = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");

                    client.BaseAddress = new Uri(processValue);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    try
                    {
                        using (var response = await client.PostAsync("api/ProcessPension/ProcessPension", content))    //Get Post Mai check kar lena
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            penDetailObj = JsonConvert.DeserializeObject<PensionDetail>(apiResponse);

                        }
                    }
                    catch(Exception e)
                    {
                        penDetailObj = null;
                    }

                }

                if (penDetailObj == null)
                {
                    ViewBag.erroroccured = "Some Error Occured";
                    return View();
                }
                if(penDetailObj.Status.Equals(20))
                {
                    ViewBag.erroroccured = "Some Error Occured";
                    return View();
                }
                if (penDetailObj.Status.Equals(10))
                {
                    // Storing the Values in Database
                    _context.pensionDetails.Add(penDetailObj);
                    _context.SaveChanges();
                    return RedirectToAction("PensionervaluesDisplayed", penDetailObj);
                }
                else
                {
                    ViewBag.notmatch = "Pensioner Values not match";
                    return View();
                }

            }

            else
            {
                ViewBag.invalid = "Pensioner Values are Invalid";
                return View();
            }

        }
        /// <summary>
        /// Displaying the Pension Amount 
        /// </summary>
        /// <param name="penObj"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult PensionervaluesDisplayed(PensionDetail penObj)
        {
            
            return View(penObj);


        }

    }
}
