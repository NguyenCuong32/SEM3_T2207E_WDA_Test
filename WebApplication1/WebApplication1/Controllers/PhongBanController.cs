using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PhongBanController : Controller
    {
        private readonly DataContext _context;

        public PhongBanController(DataContext context)
        {
            _context = context;
        }

        // GET: PhongBan
        public async Task<IActionResult> Index()
        {
              return _context.PhongBanModel != null ? 
                          View(await _context.PhongBanModel.ToListAsync()) :
                          Problem("Entity set 'DataContext.PhongBanModel'  is null.");
        }

        // GET: PhongBan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PhongBanModel == null)
            {
                return NotFound();
            }

            var phongBanModel = await _context.PhongBanModel
                .FirstOrDefaultAsync(m => m.Code == id);
            if (phongBanModel == null)
            {
                return NotFound();
            }

            return View(phongBanModel);
        }

        // GET: PhongBan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhongBan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,Name,Location,NumberOfPersonel")] PhongBanModel phongBanModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phongBanModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phongBanModel);
        }

        // GET: PhongBan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PhongBanModel == null)
            {
                return NotFound();
            }

            var phongBanModel = await _context.PhongBanModel.FindAsync(id);
            if (phongBanModel == null)
            {
                return NotFound();
            }
            return View(phongBanModel);
        }

        // POST: PhongBan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Code,Name,Location,NumberOfPersonel")] PhongBanModel phongBanModel)
        {
            if (id != phongBanModel.Code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phongBanModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhongBanModelExists(phongBanModel.Code))
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
            return View(phongBanModel);
        }

        // GET: PhongBan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PhongBanModel == null)
            {
                return NotFound();
            }

            var phongBanModel = await _context.PhongBanModel
                .FirstOrDefaultAsync(m => m.Code == id);
            if (phongBanModel == null)
            {
                return NotFound();
            }

            return View(phongBanModel);
        }

        // POST: PhongBan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PhongBanModel == null)
            {
                return Problem("Entity set 'DataContext.PhongBanModel'  is null.");
            }
            var phongBanModel = await _context.PhongBanModel.FindAsync(id);
            if (phongBanModel != null)
            {
                _context.PhongBanModel.Remove(phongBanModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhongBanModelExists(int id)
        {
          return (_context.PhongBanModel?.Any(e => e.Code == id)).GetValueOrDefault();
        }
    }
}
