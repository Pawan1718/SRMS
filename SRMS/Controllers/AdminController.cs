using Microsoft.AspNetCore.Mvc;
using SRMS.Models;
using System.Diagnostics;

namespace SRMS.Controllers
{
    public class AdminController : Controller
    {
        private readonly AdminDbContext aDC;
        public AdminController(AdminDbContext ADC)
        {
            this.aDC = ADC;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdminRegister()
        {

            return View();

        }
        [HttpPost]
        public IActionResult AdminRegister(AdminModel Adm)
        {
            if (ModelState.IsValid)
            {
                aDC.Admins.Add(Adm);
                aDC.SaveChanges();
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
            var AdmLoginVerify = aDC.Admins.Where(x => x.Email == Adm.Email && x.Password == Adm.Password).FirstOrDefault();
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
            if (HttpContext.Session.GetString("AdminSession") != null)
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