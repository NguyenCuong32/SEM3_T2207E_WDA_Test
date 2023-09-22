using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sem3_exam.Data;
using Sem3_exam.Mains.Models;

namespace Sem3_exam.Views
{
    public class TestJobsController : Controller
    {
        private readonly TestDBcontext _context;

        public TestJobsController(TestDBcontext context)
        {
            _context = context;
        }

        // GET: TestJobs
        public async Task<IActionResult> Index()
        {
              return _context.Department_Tbl != null ? 
                          View(await _context.Department_Tbl.ToListAsync()) :
                          Problem("Entity set 'TestDBcontext.Department_Tbl'  is null.");
        }

        // GET: TestJobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Department_Tbl == null)
            {
                return NotFound();
            }

            var testJob = await _context.Department_Tbl
                .FirstOrDefaultAsync(m => m.department_code == id);
            if (testJob == null)
            {
                return NotFound();
            }

            return View(testJob);
        }

        // GET: TestJobs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TestJobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("department_code,department_name,location,number_of_personals")] TestJob testJob)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testJob);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testJob);
        }

        // GET: TestJobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Department_Tbl == null)
            {
                return NotFound();
            }

            var testJob = await _context.Department_Tbl.FindAsync(id);
            if (testJob == null)
            {
                return NotFound();
            }
            return View(testJob);
        }

        // POST: TestJobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("department_code,department_name,location,number_of_personals")] TestJob testJob)
        {
            if (id != testJob.department_code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testJob);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestJobExists(testJob.department_code))
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
            return View(testJob);
        }

        // GET: TestJobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Department_Tbl == null)
            {
                return NotFound();
            }

            var testJob = await _context.Department_Tbl
                .FirstOrDefaultAsync(m => m.department_code == id);
            if (testJob == null)
            {
                return NotFound();
            }

            return View(testJob);
        }

        // POST: TestJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Department_Tbl == null)
            {
                return Problem("Entity set 'TestDBcontext.Department_Tbl'  is null.");
            }
            var testJob = await _context.Department_Tbl.FindAsync(id);
            if (testJob != null)
            {
                _context.Department_Tbl.Remove(testJob);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestJobExists(int id)
        {
          return (_context.Department_Tbl?.Any(e => e.department_code == id)).GetValueOrDefault();
        }
    }
}
