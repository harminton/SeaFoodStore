using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeaFoodStore.Areas.Identity.Data;
using SeaFoodStore.Models;

namespace SeaFoodStore.Controllers
{
    public class BrandTablesController : Controller
    {
        private readonly SeaFoodStoreContext _context;

        public BrandTablesController(SeaFoodStoreContext context)
        {
            _context = context;
        }

        // GET: BrandTables
        public async Task<IActionResult> Index()
        {
              return _context.BrandTable != null ? 
                          View(await _context.BrandTable.ToListAsync()) :
                          Problem("Entity set 'SeaFoodStoreContext.BrandTable'  is null.");
        }

        // GET: BrandTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BrandTable == null)
            {
                return NotFound();
            }

            var brandTable = await _context.BrandTable
                .FirstOrDefaultAsync(m => m.BrandId == id);
            if (brandTable == null)
            {
                return NotFound();
            }

            return View(brandTable);
        }

        // GET: BrandTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BrandTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrandId,BrandName")] BrandTable brandTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brandTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brandTable);
        }

        // GET: BrandTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BrandTable == null)
            {
                return NotFound();
            }

            var brandTable = await _context.BrandTable.FindAsync(id);
            if (brandTable == null)
            {
                return NotFound();
            }
            return View(brandTable);
        }

        // POST: BrandTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BrandId,BrandName")] BrandTable brandTable)
        {
            if (id != brandTable.BrandId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brandTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandTableExists(brandTable.BrandId))
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
            return View(brandTable);
        }

        // GET: BrandTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BrandTable == null)
            {
                return NotFound();
            }

            var brandTable = await _context.BrandTable
                .FirstOrDefaultAsync(m => m.BrandId == id);
            if (brandTable == null)
            {
                return NotFound();
            }

            return View(brandTable);
        }

        // POST: BrandTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BrandTable == null)
            {
                return Problem("Entity set 'SeaFoodStoreContext.BrandTable'  is null.");
            }
            var brandTable = await _context.BrandTable.FindAsync(id);
            if (brandTable != null)
            {
                _context.BrandTable.Remove(brandTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrandTableExists(int id)
        {
          return (_context.BrandTable?.Any(e => e.BrandId == id)).GetValueOrDefault();
        }
    }
}
