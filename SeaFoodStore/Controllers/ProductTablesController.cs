using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeaFoodStore.Areas.Identity.Data;
using SeaFoodStore.Models;

namespace SeaFoodStore.Controllers
{
    public class ProductTablesController : Controller
    {
        private readonly SeaFoodStoreContext _context;

        public ProductTablesController(SeaFoodStoreContext context)
        {
            _context = context;
        }

        // GET: ProductTables
        public async Task<IActionResult> Index()
        {
              return _context.ProductTable != null ? 
                          View(await _context.ProductTable.ToListAsync()) :
                          Problem("Entity set 'SeaFoodStoreContext.ProductTable'  is null.");
        }

        // GET: ProductTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductTable == null)
            {
                return NotFound();
            }

            var productTable = await _context.ProductTable
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productTable == null)
            {
                return NotFound();
            }

            return View(productTable);
        }

        // GET: ProductTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,BrandId,CategoryId,Price,Discount,Stock")] ProductTable productTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productTable);
        }

        // GET: ProductTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductTable == null)
            {
                return NotFound();
            }

            var productTable = await _context.ProductTable.FindAsync(id);
            if (productTable == null)
            {
                return NotFound();
            }
            return View(productTable);
        }

        // POST: ProductTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,BrandId,CategoryId,Price,Discount,Stock")] ProductTable productTable)
        {
            if (id != productTable.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductTableExists(productTable.ProductId))
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
            return View(productTable);
        }

        // GET: ProductTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductTable == null)
            {
                return NotFound();
            }

            var productTable = await _context.ProductTable
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productTable == null)
            {
                return NotFound();
            }

            return View(productTable);
        }

        // POST: ProductTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductTable == null)
            {
                return Problem("Entity set 'SeaFoodStoreContext.ProductTable'  is null.");
            }
            var productTable = await _context.ProductTable.FindAsync(id);
            if (productTable != null)
            {
                _context.ProductTable.Remove(productTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductTableExists(int id)
        {
          return (_context.ProductTable?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
