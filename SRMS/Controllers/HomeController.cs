using Microsoft.AspNetCore.Mvc;
using SRMS.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using NuGet.Configuration;

namespace SRMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly AdminDbContext adminDb;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        public HomeController(AdminDbContext adminDb)
        {
            this.adminDb = adminDb;
        }

        public IActionResult Index()
        {
            return View();
            //var AdminData = adminDb.Admins.ToList();
            //return View(AdminData);
        }
        public IActionResult AdminRegister()
        {
          
            return View();
            //var AdminData = adminDb.Admins.ToList();
            //return View(AdminData);
        }
        [HttpPost]
        public IActionResult AdminRegister(AdminModel Adm)
        {
            if (ModelState.IsValid)
            {
                adminDb.Admins.Add(Adm);
                adminDb.SaveChanges();
                TempData["SuccessMessage"] = "Registered successfully!";
                ModelState.Clear();
                Adm = new AdminModel();
            }
            return View();
        }
        public IActionResult AdminLogin()
        {
            return View();
           
        }
        [HttpPost]
        public IActionResult AdminLogin(AdminModel Adm)
        {
            var AdmLoginVerify =adminDb.Admins.Where(x => x.Email == Adm.Email && x.Password == Adm.Password).FirstOrDefault();
            if (AdmLoginVerify != null)
            {
                HttpContext.Session.SetString("AdminSession", AdmLoginVerify.Email);
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.Message = "Login Failed";
            }
            return View();

        }

        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("AdminSession") !=null)
            {
                ViewBag.AdmSession = HttpContext.Session.GetString("AdminSession");
            }
            else
            {
                return RedirectToAction("AdminLogin");
            }
            return View();

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