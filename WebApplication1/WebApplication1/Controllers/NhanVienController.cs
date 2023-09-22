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
    public class NhanVienController : Controller
    {
        private readonly DataContext _context;

        public NhanVienController(DataContext context)
        {
            _context = context;
        }

        // GET: NhanVien
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.NhanVienModel.Include(n => n.PhongBan);
            return View(await dataContext.ToListAsync());
        }

        // GET: NhanVien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NhanVienModel == null)
            {
                return NotFound();
            }

            var nhanVienModel = await _context.NhanVienModel
                .Include(n => n.PhongBan)
                .FirstOrDefaultAsync(m => m.Code == id);
            if (nhanVienModel == null)
            {
                return NotFound();
            }

            return View(nhanVienModel);
        }

        // GET: NhanVien/Create
        public IActionResult Create()
        {
            ViewData["PhongBanCode"] = new SelectList(_context.PhongBanModel, "Code", "Location");
            return View();
        }

        // POST: NhanVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,Name,PhongBanCode,Rank")] NhanVienModel nhanVienModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanVienModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PhongBanCode"] = new SelectList(_context.PhongBanModel, "Code", "Location", nhanVienModel.PhongBanCode);
            return View(nhanVienModel);
        }

        // GET: NhanVien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NhanVienModel == null)
            {
                return NotFound();
            }

            var nhanVienModel = await _context.NhanVienModel.FindAsync(id);
            if (nhanVienModel == null)
            {
                return NotFound();
            }
            ViewData["PhongBanCode"] = new SelectList(_context.PhongBanModel, "Code", "Location", nhanVienModel.PhongBanCode);
            return View(nhanVienModel);
        }

        // POST: NhanVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Code,Name,PhongBanCode,Rank")] NhanVienModel nhanVienModel)
        {
            if (id != nhanVienModel.Code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanVienModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienModelExists(nhanVienModel.Code))
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
            ViewData["PhongBanCode"] = new SelectList(_context.PhongBanModel, "Code", "Location", nhanVienModel.PhongBanCode);
            return View(nhanVienModel);
        }

        // GET: NhanVien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NhanVienModel == null)
            {
                return NotFound();
            }

            var nhanVienModel = await _context.NhanVienModel
                .Include(n => n.PhongBan)
                .FirstOrDefaultAsync(m => m.Code == id);
            if (nhanVienModel == null)
            {
                return NotFound();
            }

            return View(nhanVienModel);
        }

        // POST: NhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NhanVienModel == null)
            {
                return Problem("Entity set 'DataContext.NhanVienModel'  is null.");
            }
            var nhanVienModel = await _context.NhanVienModel.FindAsync(id);
            if (nhanVienModel != null)
            {
                _context.NhanVienModel.Remove(nhanVienModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienModelExists(int id)
        {
          return (_context.NhanVienModel?.Any(e => e.Code == id)).GetValueOrDefault();
        }
    }
}
