using Growth_Website.Models.Interface;
using JqueryAjaxPostExample.Models;
using Microsoft.AspNetCore.Mvc;
using testing2.Models;
using System.Diagnostics;
namespace testing2.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly depLogin empRepo;
        public LoginController(ILogger<LoginController> logger, depLogin d)
        {
            empRepo = d;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult StudentLogin()
        {
           
            string data = String.Empty;
            if (HttpContext.Session.Keys.Contains("first_request"))
            {
                string firstVisitedDateTime = HttpContext.Session.GetString("first_request");
                data = "Welcome back " + firstVisitedDateTime;
            }
            else
            {
                data = "Visited first time";
                HttpContext.Session.SetString("first_request", "dear");
            }
            return View("StudentLogin", data);
        }
        public IActionResult Remove()
        {
            //HttpContext.Response.Cookies.Delete("first_request");
            HttpContext.Session.Remove("first_request");
            return View("StudentLogin");
        }

        [HttpPost]
        public IActionResult StudentLogin(Login sp)
        {
            Login login = new Login();

             login = empRepo.CheckLoginInfo(sp);
            if (login.Isavailable==true)
            {
                HttpContext.Session.SetString("userName", login.LoginUserName);
                HttpContext.Session.SetInt32("userId", login.id);
                return RedirectToAction(actionName: "ShowResult", controllerName: "Home");
            }
            else
            {
                
                ViewBag.s = "Invalid UserName or password";
                return View();
            }
        }

        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminLogin(Login sp)
        {
            Login login = new Login();

            login = empRepo.CheckLoginInfoAdmin(sp);
            if (login.Isavailable == true)
            {
                HttpContext.Session.SetString("userName", login.LoginUserName);
                HttpContext.Session.SetInt32("userId", login.id);
                return RedirectToAction(actionName: "Upload", controllerName: "Product");
            }
            else
            {

                ViewBag.s = "Invalid UserName or password";
                return View();
            }
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
