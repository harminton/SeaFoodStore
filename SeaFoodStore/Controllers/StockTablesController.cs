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
    public class StockTablesController : Controller
    {
        private readonly SeaFoodStoreContext _context;

        public StockTablesController(SeaFoodStoreContext context)
        {
            _context = context;
        }

        // GET: StockTables
        public async Task<IActionResult> Index()
        {
              return _context.StockTable != null ? 
                          View(await _context.StockTable.ToListAsync()) :
                          Problem("Entity set 'SeaFoodStoreContext.StockTable'  is null.");
        }

        // GET: StockTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StockTable == null)
            {
                return NotFound();
            }

            var stockTable = await _context.StockTable
                .FirstOrDefaultAsync(m => m.StockId == id);
            if (stockTable == null)
            {
                return NotFound();
            }

            return View(stockTable);
        }

        // GET: StockTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StockTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StockId,ProductId,StoreId,Quantity")] StockTable stockTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stockTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stockTable);
        }

        // GET: StockTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StockTable == null)
            {
                return NotFound();
            }

            var stockTable = await _context.StockTable.FindAsync(id);
            if (stockTable == null)
            {
                return NotFound();
            }
            return View(stockTable);
        }

        // POST: StockTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StockId,ProductId,StoreId,Quantity")] StockTable stockTable)
        {
            if (id != stockTable.StockId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockTableExists(stockTable.StockId))
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
            return View(stockTable);
        }

        // GET: StockTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StockTable == null)
            {
                return NotFound();
            }

            var stockTable = await _context.StockTable
                .FirstOrDefaultAsync(m => m.StockId == id);
            if (stockTable == null)
            {
                return NotFound();
            }

            return View(stockTable);
        }

        // POST: StockTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StockTable == null)
            {
                return Problem("Entity set 'SeaFoodStoreContext.StockTable'  is null.");
            }
            var stockTable = await _context.StockTable.FindAsync(id);
            if (stockTable != null)
            {
                _context.StockTable.Remove(stockTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockTableExists(int id)
        {
          return (_context.StockTable?.Any(e => e.StockId == id)).GetValueOrDefault();
        }
    }
}
