using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SRMS.Models;

namespace SRMS.Controllers
{
    public class ClassController : Controller
    {
        private readonly ClassDbContext clsDb;

        public ClassController(ClassDbContext ClsDb)
        {
           this.clsDb = ClsDb;
        }
        public async Task<IActionResult> ClassIndex()
        {
            var clsData = await clsDb.Classes.ToListAsync();
            return View(clsData);
        }
        public async Task<IActionResult> AddClass()
        {
         
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddClass(ClassModel Cls)
        {
            if (ModelState.IsValid)
            {
                var clsData = await clsDb.Classes.AddAsync(Cls);
                await clsDb.SaveChangesAsync();
                TempData["Success Message"] = "Record Create Successfully";
                
            }
            return View();
        }
        [HttpGet("/Class/UpdateClass/{Id}")]
        public async Task <IActionResult> UpdateClass(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var clsData = await clsDb.Classes.FirstOrDefaultAsync(s => s.Id == Id);

            if (clsData == null)
            {
                return NotFound();
            }

            return View(clsData);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateClass(int Id, ClassModel cls)
        {
            if (Id != cls.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                clsDb.Classes.Update(cls);
                await clsDb.SaveChangesAsync();
                return RedirectToAction("ClassIndex");
            }

            return View(cls);
        }
    }
}
