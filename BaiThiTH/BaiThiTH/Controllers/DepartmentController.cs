using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaiThiTH;
using BaiThiTH.Models;

namespace BaiThiTH.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ProductDbContext _context;

        public DepartmentController(ProductDbContext context)
        {
            _context = context;
        }

        // GET: Department
        public async Task<IActionResult> Index()
        {
              return _context.Department_Tbl != null ? 
                          View(await _context.Department_Tbl.ToListAsync()) :
                          Problem("Entity set 'ProductDbContext.Department_Tbl'  is null.");
        }

        // GET: Department/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Department_Tbl == null)
            {
                return NotFound();
            }

            var department = await _context.Department_Tbl
                .FirstOrDefaultAsync(m => m.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Department/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DepartmentName,DepartmentCode,Location,numberOfPersonals")] Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Department/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Department_Tbl == null)
            {
                return NotFound();
            }

            var department = await _context.Department_Tbl.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Department/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DepartmentName,DepartmentCode,Location,numberOfPersonals")] Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(department);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.Id))
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
            return View(department);
        }

        // GET: Department/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Department_Tbl == null)
            {
                return NotFound();
            }

            var department = await _context.Department_Tbl
                .FirstOrDefaultAsync(m => m.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Department_Tbl == null)
            {
                return Problem("Entity set 'ProductDbContext.Department_Tbl'  is null.");
            }
            var department = await _context.Department_Tbl.FindAsync(id);
            if (department != null)
            {
                _context.Department_Tbl.Remove(department);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists(int id)
        {
          return (_context.Department_Tbl?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
