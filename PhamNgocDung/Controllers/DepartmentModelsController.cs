using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhamNgocDung.DAL;
using PhamNgocDung.Models;

namespace PhamNgocDung.Controllers
{
    public class DepartmentModelsController : Controller
    {
        private readonly ExamDbContext _context;

        public DepartmentModelsController(ExamDbContext context)
        {
            _context = context;
        }

        // GET: DepartmentModels
        public async Task<IActionResult> Index()
        {
            List<DepartmentModel> departments = _context.Departments
                .Take(10)
                .OrderBy(d => d.departmentName)
                .ToList();
            return View(departments);


        }

        // GET: DepartmentModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Departments == null)
            {
                return NotFound();
            }

            var departmentModel = await _context.Departments
                .FirstOrDefaultAsync(m => m.departmentId == id);
            if (departmentModel == null)
            {
                return NotFound();
            }

            return View(departmentModel);
        }

        // GET: DepartmentModels/Create
        public IActionResult Create()
        {
            List<DepartmentModel> departments = _context.Departments.ToList();
            var selectDepartments = new List<SelectListItem>();
            foreach (var d in departments)
            {
                selectDepartments.Add(new SelectListItem { Text = d.departmentName, Value = d.departmentId.ToString() });
            }
            ViewBag.departments = selectDepartments;
            return View();
        }


        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("departmentId,departmentName,departmentCode,departmentLocation,departmentNumbPersonals")] DepartmentModel departmentModel)
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Departments == null)
            {
                return NotFound();
            }

            var departmentModel = await _context.Departments.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("departmentId,departmentName,departmentCode,departmentLocation,departmentNumbPersonals")] DepartmentModel departmentModel)
        {
            if (id != departmentModel.departmentId)
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
                    if (!DepartmentModelExists(departmentModel.departmentId))
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Departments == null)
            {
                return NotFound();
            }

            var departmentModel = await _context.Departments
                .FirstOrDefaultAsync(m => m.departmentId == id);
            if (departmentModel == null)
            {
                return NotFound();
            }

            return View(departmentModel);
        }

        // POST: DepartmentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Departments == null)
            {
                return Problem("Entity set 'ExamDbContext.Departments'  is null.");
            }
            var departmentModel = await _context.Departments.FindAsync(id);
            if (departmentModel != null)
            {
                _context.Departments.Remove(departmentModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentModelExists(int id)
        {
          return (_context.Departments?.Any(e => e.departmentId == id)).GetValueOrDefault();
        }
    }
}
