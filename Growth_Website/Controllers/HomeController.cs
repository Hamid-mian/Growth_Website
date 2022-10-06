using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testing2.Models;
using System.Diagnostics;
using Growth_Website.Models;

namespace testing2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment Environment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            Environment = environment;
        }
        public ViewResult ShowResult()
        {
            List<Signup> signup_list = new List<Signup>();

            ViewBag.SL = signup_list;

            
            return View();
        }
       
      
    }
}