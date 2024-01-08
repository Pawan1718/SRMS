using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SRMS.Models;

namespace SRMS.Controllers
{
    public class SubjectController : Controller
    {
        private readonly SubjectDbContext _context;

        public SubjectController(SubjectDbContext context)
        {
            _context = context;
        }

        // GET: Subject
        public async Task<IActionResult> Index()
        {
              return _context.Subjects != null ? 
                          View(await _context.Subjects.ToListAsync()) :
                          Problem("Entity set 'SubjectDbContext.Subjects'  is null.");
        }

        // GET: Subject/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Subjects == null)
            {
                return NotFound();
            }

            var subjectModel = await _context.Subjects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subjectModel == null)
            {
                return NotFound();
            }

            return View(subjectModel);
        }

        // GET: Subject/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subject/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Std,SubjectName,SubjectCode,Description")] SubjectModel subjectModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subjectModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subjectModel);
        }

        // GET: Subject/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Subjects == null)
            {
                return NotFound();
            }

            var subjectModel = await _context.Subjects.FindAsync(id);
            if (subjectModel == null)
            {
                return NotFound();
            }
            return View(subjectModel);
        }

        // POST: Subject/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Std,SubjectName,SubjectCode,Description")] SubjectModel subjectModel)
        {
            if (id != subjectModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subjectModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectModelExists(subjectModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(subjectModel);
        }

        // GET: Subject/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Subjects == null)
            {
                return NotFound();
            }

            var subjectModel = await _context.Subjects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subjectModel == null)
            {
                return NotFound();
            }

            return View(subjectModel);
        }

        // POST: Subject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Subjects == null)
            {
                return Problem("Entity set 'SubjectDbContext.Subjects'  is null.");
            }
            var subjectModel = await _context.Subjects.FindAsync(id);
            if (subjectModel != null)
            {
                _context.Subjects.Remove(subjectModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectModelExists(int id)
        {
          return (_context.Subjects?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
