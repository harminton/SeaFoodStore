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
    public class CategoriesTablesController : Controller
    {
        private readonly SeaFoodStoreContext _context;

        public CategoriesTablesController(SeaFoodStoreContext context)
        {
            _context = context;
        }

        // GET: CategoriesTables
        public async Task<IActionResult> Index()
        {
              return _context.CategoriesTable != null ? 
                          View(await _context.CategoriesTable.ToListAsync()) :
                          Problem("Entity set 'SeaFoodStoreContext.CategoriesTable'  is null.");
        }

        // GET: CategoriesTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CategoriesTable == null)
            {
                return NotFound();
            }

            var categoriesTable = await _context.CategoriesTable
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (categoriesTable == null)
            {
                return NotFound();
            }

            return View(categoriesTable);
        }

        // GET: CategoriesTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriesTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName")] CategoriesTable categoriesTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriesTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriesTable);
        }

        // GET: CategoriesTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CategoriesTable == null)
            {
                return NotFound();
            }

            var categoriesTable = await _context.CategoriesTable.FindAsync(id);
            if (categoriesTable == null)
            {
                return NotFound();
            }
            return View(categoriesTable);
        }

        // POST: CategoriesTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName")] CategoriesTable categoriesTable)
        {
            if (id != categoriesTable.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriesTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriesTableExists(categoriesTable.CategoryId))
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
            return View(categoriesTable);
        }

        // GET: CategoriesTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CategoriesTable == null)
            {
                return NotFound();
            }

            var categoriesTable = await _context.CategoriesTable
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (categoriesTable == null)
            {
                return NotFound();
            }

            return View(categoriesTable);
        }

        // POST: CategoriesTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CategoriesTable == null)
            {
                return Problem("Entity set 'SeaFoodStoreContext.CategoriesTable'  is null.");
            }
            var categoriesTable = await _context.CategoriesTable.FindAsync(id);
            if (categoriesTable != null)
            {
                _context.CategoriesTable.Remove(categoriesTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriesTableExists(int id)
        {
          return (_context.CategoriesTable?.Any(e => e.CategoryId == id)).GetValueOrDefault();
        }
    }
}
