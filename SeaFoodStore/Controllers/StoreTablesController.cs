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
    public class StoreTablesController : Controller
    {
        private readonly SeaFoodStoreContext _context;

        public StoreTablesController(SeaFoodStoreContext context)
        {
            _context = context;
        }

        // GET: StoreTables
        public async Task<IActionResult> Index()
        {
              return _context.StoreTable != null ? 
                          View(await _context.StoreTable.ToListAsync()) :
                          Problem("Entity set 'SeaFoodStoreContext.StoreTable'  is null.");
        }

        // GET: StoreTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StoreTable == null)
            {
                return NotFound();
            }

            var storeTable = await _context.StoreTable
                .FirstOrDefaultAsync(m => m.StoreId == id);
            if (storeTable == null)
            {
                return NotFound();
            }

            return View(storeTable);
        }

        // GET: StoreTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StoreTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoreId,StoreName")] StoreTable storeTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storeTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(storeTable);
        }

        // GET: StoreTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StoreTable == null)
            {
                return NotFound();
            }

            var storeTable = await _context.StoreTable.FindAsync(id);
            if (storeTable == null)
            {
                return NotFound();
            }
            return View(storeTable);
        }

        // POST: StoreTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StoreId,StoreName")] StoreTable storeTable)
        {
            if (id != storeTable.StoreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storeTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoreTableExists(storeTable.StoreId))
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
            return View(storeTable);
        }

        // GET: StoreTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StoreTable == null)
            {
                return NotFound();
            }

            var storeTable = await _context.StoreTable
                .FirstOrDefaultAsync(m => m.StoreId == id);
            if (storeTable == null)
            {
                return NotFound();
            }

            return View(storeTable);
        }

        // POST: StoreTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StoreTable == null)
            {
                return Problem("Entity set 'SeaFoodStoreContext.StoreTable'  is null.");
            }
            var storeTable = await _context.StoreTable.FindAsync(id);
            if (storeTable != null)
            {
                _context.StoreTable.Remove(storeTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoreTableExists(int id)
        {
          return (_context.StoreTable?.Any(e => e.StoreId == id)).GetValueOrDefault();
        }
    }
}
