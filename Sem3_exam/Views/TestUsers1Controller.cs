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
    public class TestUsers1Controller : Controller
    {
        private readonly TestDBcontext _context;

        public TestUsers1Controller(TestDBcontext context)
        {
            _context = context;
        }

        // GET: TestUsers1
        public async Task<IActionResult> Index()
        {
            var testDBcontext = _context.Employee_Tbl.Include(t => t.TypeJob);
            return View(await testDBcontext.ToListAsync());
        }

        // GET: TestUsers1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employee_Tbl == null)
            {
                return NotFound();
            }

            var testUser = await _context.Employee_Tbl
                .Include(t => t.TypeJob)
                .FirstOrDefaultAsync(m => m.employee_code == id);
            if (testUser == null)
            {
                return NotFound();
            }

            return View(testUser);
        }

        // GET: TestUsers1/Create
        public IActionResult Create()
        {
            ViewData["department_code"] = new SelectList(_context.Department_Tbl, "department_code", "department_name");
            return View();
        }

        // POST: TestUsers1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("employee_code,employee_name,department_code,employee_rnk")] TestUser testUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["department_code"] = new SelectList(_context.Department_Tbl, "department_code", "department_name", testUser.department_code);
            return View(testUser);
        }

        // GET: TestUsers1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employee_Tbl == null)
            {
                return NotFound();
            }

            var testUser = await _context.Employee_Tbl.FindAsync(id);
            if (testUser == null)
            {
                return NotFound();
            }
            ViewData["department_code"] = new SelectList(_context.Department_Tbl, "department_code", "department_name", testUser.department_code);
            return View(testUser);
        }

        // POST: TestUsers1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("employee_code,employee_name,department_code,employee_rnk")] TestUser testUser)
        {
            if (id != testUser.employee_code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestUserExists(testUser.employee_code))
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
            ViewData["department_code"] = new SelectList(_context.Department_Tbl, "department_code", "department_name", testUser.department_code);
            return View(testUser);
        }

        // GET: TestUsers1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employee_Tbl == null)
            {
                return NotFound();
            }

            var testUser = await _context.Employee_Tbl
                .Include(t => t.TypeJob)
                .FirstOrDefaultAsync(m => m.employee_code == id);
            if (testUser == null)
            {
                return NotFound();
            }

            return View(testUser);
        }

        // POST: TestUsers1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employee_Tbl == null)
            {
                return Problem("Entity set 'TestDBcontext.Employee_Tbl'  is null.");
            }
            var testUser = await _context.Employee_Tbl.FindAsync(id);
            if (testUser != null)
            {
                _context.Employee_Tbl.Remove(testUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestUserExists(int id)
        {
          return (_context.Employee_Tbl?.Any(e => e.employee_code == id)).GetValueOrDefault();
        }
    }
}
