using Growth_Website.Models;
using Growth_Website.Models.Interface;
using Microsoft.AspNetCore.Mvc;
namespace Growth_Website.Controllers
{
    public class CartController : Controller
    {
   
        private readonly depCart empRepo;
        public CartController( depCart d)
        {
            empRepo = d;
        }

        [HttpGet]
        public ViewResult Carts()
        {
            List<Cart> p = new List<Cart>();
            p = empRepo.GetCart();
            if(p!=null)
            {
                return View("Carts", p);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Carts(Products p)
        {
            Cart ct = new Cart();
            ct.customerName= HttpContext.Session.GetString("userName");
            ct.customerId = HttpContext.Session.GetInt32("userId");
            ct.imagename = p.imagename;
            ct.productName = p.productName;
            ct.productType = p.productType;
            ct.price = p.price;
            empRepo.addcart(ct);
            return View();
        } 

        public void getData(Cart p)
        {
            empRepo.removeCart(p);
        }

        public void Removeall()
        {
            empRepo.removeall();
        }
    }
}
