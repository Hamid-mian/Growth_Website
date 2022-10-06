using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testing2.Models;

namespace testing2.Controllers
{
    public class AboutusController : Controller
    {
        public ViewResult About()
        {
           
            return View();
        }
    }
}