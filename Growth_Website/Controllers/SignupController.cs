using Growth_Website.Models.Interface;
using Growth_Website.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using testing2.Models;

namespace testing2.Controllers
{
    public class SignupController : Controller
    {
        private readonly ILogger<SignupController> _logger;
        private readonly depSignup empRepo;
        public SignupController(ILogger<SignupController> logger, depSignup d)
        {
            empRepo = d;
            _logger = logger;
        }
        [HttpGet]
        public ViewResult StudentForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult StudentForm( Signup sp)
        {
            sp.loginas = "user";
            string status = empRepo.AddSignupData(sp);
            if(status ==null)
            {
                return RedirectToAction(actionName: "StudentLogin", controllerName: "Login");
            }
            else
            {
                ViewBag.s = "Enter All the required fields";
                return View();
            }

        }

        [HttpGet]
        public ViewResult AdminForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminForm(Signup sp)
        {
            sp.loginas = "admin";
            string status = empRepo.AddSignupData(sp);
            if (status == null)
            {
                ViewBag.s = "Admin Added Successfully";
                return View();
            }
            else
            {
                ViewBag.s = "Enter All the required fields";
                return View();
            }

        }
    }
}
