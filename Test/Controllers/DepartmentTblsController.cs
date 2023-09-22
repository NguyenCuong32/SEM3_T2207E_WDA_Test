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
    public class DepartmentTblsController : Controller
    {
        private readonly HrManagerContext _context;

        public DepartmentTblsController(HrManagerContext context)
        {
            _context = context;
        }

        // GET: DepartmentTbls
        public async Task<IActionResult> Index()
        {
              return _context.DepartmentTbls != null ? 
                          View(await _context.DepartmentTbls.ToListAsync()) :
                          Problem("Entity set 'HrManagerContext.DepartmentTbls'  is null.");
        }

        // GET: DepartmentTbls/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.DepartmentTbls == null)
            {
                return NotFound();
            }

            var departmentTbl = await _context.DepartmentTbls
                .FirstOrDefaultAsync(m => m.DepartmentId == id);
            departmentTbl.EmployeeTbls = await _context.EmployeeTbls.Where(x => x.Department == id).ToListAsync();

            if (departmentTbl == null)
            {
                return NotFound();
            }

            return View(departmentTbl);
        }

        // GET: DepartmentTbls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DepartmentTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentId,DepartmentName,Location")] DepartmentTbl departmentTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmentTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departmentTbl);
        }

        // GET: DepartmentTbls/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.DepartmentTbls == null)
            {
                return NotFound();
            }

            var departmentTbl = await _context.DepartmentTbls.FindAsync(id);
            if (departmentTbl == null)
            {
                return NotFound();
            }
            return View(departmentTbl);
        }

        // POST: DepartmentTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DepartmentId,DepartmentName,Location")] DepartmentTbl departmentTbl)
        {
            if (id != departmentTbl.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmentTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentTblExists(departmentTbl.DepartmentId))
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
            return View(departmentTbl);
        }

        // GET: DepartmentTbls/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.DepartmentTbls == null)
            {
                return NotFound();
            }

            var departmentTbl = await _context.DepartmentTbls
                .FirstOrDefaultAsync(m => m.DepartmentId == id);
            if (departmentTbl == null)
            {
                return NotFound();
            }

            return View(departmentTbl);
        }

        // POST: DepartmentTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.DepartmentTbls == null)
            {
                return Problem("Entity set 'HrManagerContext.DepartmentTbls'  is null.");
            }
            var departmentTbl = await _context.DepartmentTbls.FindAsync(id);
            if (departmentTbl != null)
            {
                _context.DepartmentTbls.Remove(departmentTbl);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentTblExists(string id)
        {
          return (_context.DepartmentTbls?.Any(e => e.DepartmentId == id)).GetValueOrDefault();
        }
    }
}
