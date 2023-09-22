using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Controllers
{
    public class EmployeeTblsController : Controller
    {
        private readonly HrManagerContext _context;

        public EmployeeTblsController(HrManagerContext context)
        {
            _context = context;
        }

        // GET: EmployeeTbls
        public async Task<IActionResult> Index()
        {
            var hrManagerContext = _context.EmployeeTbls.Include(e => e.DepartmentNavigation);
            return View(await hrManagerContext.ToListAsync());
        }

        // GET: EmployeeTbls/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.EmployeeTbls == null)
            {
                return NotFound();
            }

            var employeeTbl = await _context.EmployeeTbls
                .Include(e => e.DepartmentNavigation)
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (employeeTbl == null)
            {
                return NotFound();
            }

            return View(employeeTbl);
        }

        // GET: EmployeeTbls/Create
        public IActionResult Create()
        {
            ViewData["Department"] = new SelectList(_context.DepartmentTbls, "DepartmentId", "DepartmentId");
            return View();
        }

        // POST: EmployeeTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpId,EmpName,Department,Rank,Mail,Password")] EmployeeTbl employeeTbl)
        {
            try
            {
                _context.Add(employeeTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["Department"] = new SelectList(_context.DepartmentTbls, "DepartmentId", "DepartmentId", employeeTbl.Department);
                return View(employeeTbl);
            }
                
            
        }

        // GET: EmployeeTbls/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.EmployeeTbls == null)
            {
                return NotFound();
            }

            var employeeTbl = await _context.EmployeeTbls.FindAsync(id);
            if (employeeTbl == null)
            {
                return NotFound();
            }
            ViewData["Department"] = new SelectList(_context.DepartmentTbls, "DepartmentId", "DepartmentId", employeeTbl.Department);
            return View(employeeTbl);
        }

        // POST: EmployeeTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EmpId,EmpName,Department,Rank,Mail,Password")] EmployeeTbl employeeTbl)
        {
            if (id != employeeTbl.EmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeTblExists(employeeTbl.EmpId))
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
            ViewData["Department"] = new SelectList(_context.DepartmentTbls, "DepartmentId", "DepartmentId", employeeTbl.Department);
            return View(employeeTbl);
        }

        // GET: EmployeeTbls/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.EmployeeTbls == null)
            {
                return NotFound();
            }

            var employeeTbl = await _context.EmployeeTbls
                .Include(e => e.DepartmentNavigation)
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (employeeTbl == null)
            {
                return NotFound();
            }

            return View(employeeTbl);
        }

        // POST: EmployeeTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.EmployeeTbls == null)
            {
                return Problem("Entity set 'HrManagerContext.EmployeeTbls'  is null.");
            }
            var employeeTbl = await _context.EmployeeTbls.FindAsync(id);
            if (employeeTbl != null)
            {
                _context.EmployeeTbls.Remove(employeeTbl);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeTblExists(string id)
        {
          return (_context.EmployeeTbls?.Any(e => e.EmpId == id)).GetValueOrDefault();
        }
    }
}
