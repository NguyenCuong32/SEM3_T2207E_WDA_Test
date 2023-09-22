using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Exam.DBcontextEx;
using Exam.Models;

namespace Exam.Controllers
{
    public class DepartmentModelsController : Controller
    {
        private readonly DbContextDe _context;

        public DepartmentModelsController(DbContextDe context)
        {
            _context = context;
        }

        // GET: DepartmentModels
        public async Task<IActionResult> Index()
        {
              return _context.DepartmentModel != null ? 
                          View(await _context.DepartmentModel.ToListAsync()) :
                          Problem("Entity set 'DbContextDe.DepartmentModel'  is null.");
        }

        // GET: DepartmentModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.DepartmentModel == null)
            {
                return NotFound();
            }

            var departmentModel = await _context.DepartmentModel
                .FirstOrDefaultAsync(m => m.DepartmentName == id);
            if (departmentModel == null)
            {
                return NotFound();
            }

            return View(departmentModel);
        }

        // GET: DepartmentModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DepartmentModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentName,DepartmentCode,Location,Number_of_personals")] DepartmentModel departmentModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departmentModel);
        }

        // GET: DepartmentModels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.DepartmentModel == null)
            {
                return NotFound();
            }

            var departmentModel = await _context.DepartmentModel.FindAsync(id);
            if (departmentModel == null)
            {
                return NotFound();
            }
            return View(departmentModel);
        }

        // POST: DepartmentModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DepartmentName,DepartmentCode,Location,Number_of_personals")] DepartmentModel departmentModel)
        {
            if (id != departmentModel.DepartmentName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentModelExists(departmentModel.DepartmentName))
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
            return View(departmentModel);
        }

        // GET: DepartmentModels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.DepartmentModel == null)
            {
                return NotFound();
            }

            var departmentModel = await _context.DepartmentModel
                .FirstOrDefaultAsync(m => m.DepartmentName == id);
            if (departmentModel == null)
            {
                return NotFound();
            }

            return View(departmentModel);
        }

        // POST: DepartmentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.DepartmentModel == null)
            {
                return Problem("Entity set 'DbContextDe.DepartmentModel'  is null.");
            }
            var departmentModel = await _context.DepartmentModel.FindAsync(id);
            if (departmentModel != null)
            {
                _context.DepartmentModel.Remove(departmentModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentModelExists(string id)
        {
          return (_context.DepartmentModel?.Any(e => e.DepartmentName == id)).GetValueOrDefault();
        }
    }
}
