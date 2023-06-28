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
    public class CustomerTablesController : Controller
    {
        private readonly SeaFoodStoreContext _context;

        public CustomerTablesController(SeaFoodStoreContext context)
        {
            _context = context;
        }

        // GET: CustomerTables
        public async Task<IActionResult> Index()
        {
              return _context.CustomerTable != null ? 
                          View(await _context.CustomerTable.ToListAsync()) :
                          Problem("Entity set 'SeaFoodStoreContext.CustomerTable'  is null.");
        }

        // GET: CustomerTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CustomerTable == null)
            {
                return NotFound();
            }

            var customerTable = await _context.CustomerTable
                .FirstOrDefaultAsync(m => m.CustomerID == id);
            if (customerTable == null)
            {
                return NotFound();
            }

            return View(customerTable);
        }

        // GET: CustomerTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerID,FirstName,LastName,Phone,Email,Street,City,State,ZipCode")] CustomerTable customerTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerTable);
        }

        // GET: CustomerTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CustomerTable == null)
            {
                return NotFound();
            }

            var customerTable = await _context.CustomerTable.FindAsync(id);
            if (customerTable == null)
            {
                return NotFound();
            }
            return View(customerTable);
        }

        // POST: CustomerTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerID,FirstName,LastName,Phone,Email,Street,City,State,ZipCode")] CustomerTable customerTable)
        {
            if (id != customerTable.CustomerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerTableExists(customerTable.CustomerID))
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
            return View(customerTable);
        }

        // GET: CustomerTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CustomerTable == null)
            {
                return NotFound();
            }

            var customerTable = await _context.CustomerTable
                .FirstOrDefaultAsync(m => m.CustomerID == id);
            if (customerTable == null)
            {
                return NotFound();
            }

            return View(customerTable);
        }

        // POST: CustomerTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CustomerTable == null)
            {
                return Problem("Entity set 'SeaFoodStoreContext.CustomerTable'  is null.");
            }
            var customerTable = await _context.CustomerTable.FindAsync(id);
            if (customerTable != null)
            {
                _context.CustomerTable.Remove(customerTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerTableExists(int id)
        {
          return (_context.CustomerTable?.Any(e => e.CustomerID == id)).GetValueOrDefault();
        }
    }
}
