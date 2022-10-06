using AutoMapper;
using Growth_Website.Models;
using Growth_Website.Models.Interface;
using Growth_Website.Models.Repository;
using Growth_Website.ViewModel;
using Microsoft.AspNetCore.Mvc;
using testing2.Models;

namespace Growth_Website.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IWebHostEnvironment Environment;
        private readonly depProduct empRepo;
        private readonly IMapper _imapper;
        public ProductController(IWebHostEnvironment En, ILogger<ProductController> logger, depProduct d,IMapper mapper)
        {
            empRepo = d;
            _logger = logger;
            Environment = En;
            _imapper = mapper;
        }
        public IActionResult Index()
        {
           
            return View();
        }

        public ViewResult Collection()
        {
            List<Products> p = new List<Products>();
            p=empRepo.GetCollections();
            return View("Collection", p);
        }

        public ViewResult Popular()
        {
            List<Products> p = new List<Products>();
            p = empRepo.GetPopular();
            return View("Popular", p);
        }

        public ViewResult Special()
        {
            List<Products> Product_list1 = empRepo.GetSpecials();
            

            List<ProductViewModel> p = new List<ProductViewModel>();
            foreach (Products i in Product_list1)
            {
                var pp = _imapper.Map<ProductViewModel>(i);
                p.Add(pp);
            }
            return View("Special", p);
        }
        public ViewResult Upload()
        {

            return View();
        }
        [HttpPost]
        public ViewResult Upload(Products p, List<IFormFile> postedFiles)
        {
            
            string wwwPath = this.Environment.WebRootPath;
            string path = Path.Combine(wwwPath, "Uploads");
            var fileName="";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var file in postedFiles)
            {
                fileName = Path.GetFileName(file.FileName);
                var pathWithFileName = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(pathWithFileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                    ViewBag.Message = "file uploaded successfully";
                }
            }
            p.imagename = fileName;
            p.createdByUserName=p.LastModifiedUserId= HttpContext.Session.GetString("userName");
            empRepo.addToDatabase(p);
            return View();
        }

        [HttpGet]
        public ViewResult Update()
        {

            return View();
        }
        [HttpPost]
        public ViewResult Update(Products p, String productupName)
        {
            p.LastModifiedUserId = HttpContext.Session.GetString("userName");
            bool istrue = empRepo.Update(p, productupName);
            if (istrue)
            {
                ViewBag.Message = "File Updated Succussfully";
            }
            else
            {
                ViewBag.Message = "File does not exist";
            }
            return View();
        }

        [HttpGet]
        public ViewResult Delete()
        {

            return View();
        }
        [HttpPost]
        public ViewResult Delete(Products p)
        {
           bool istrue= empRepo.Delete(p);
            if(istrue)
            {
                ViewBag.Message = "File deleted Succussfully";
            }else
            {
                ViewBag.Message = "File does not exist";
            }
            return View();
        }

        [HttpGet]
        public ViewResult Search()
        {

            return View();
        }
        [HttpPost]
        public ViewResult Search(Products p)
        {
           
            return View();
        }

        public JsonResult getSearch(Products p)
        {
            List<Products> p1 = new List<Products>();
                p1 = empRepo.Search(p);
            return new JsonResult(Ok(p1));
        }

    }
}
