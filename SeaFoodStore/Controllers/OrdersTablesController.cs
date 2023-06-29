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
    [Authorize]
    public class OrdersTablesController : Controller
    {
        private readonly SeaFoodStoreContext _context;

        public OrdersTablesController(SeaFoodStoreContext context)
        {
            _context = context;
        }

        // GET: OrdersTables
        public async Task<IActionResult> Index()
        {
              return _context.OrdersTable != null ? 
                          View(await _context.OrdersTable.ToListAsync()) :
                          Problem("Entity set 'SeaFoodStoreContext.OrdersTable'  is null.");
        }

        // GET: OrdersTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrdersTable == null)
            {
                return NotFound();
            }

            var ordersTable = await _context.OrdersTable
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (ordersTable == null)
            {
                return NotFound();
            }

            return View(ordersTable);
        }

        // GET: OrdersTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrdersTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,CustomerId,OrderStatus,OrderDate,RequiredDate,ShippedDate,StoreId,BrandId")] OrdersTable ordersTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordersTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ordersTable);
        }

        // GET: OrdersTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrdersTable == null)
            {
                return NotFound();
            }

            var ordersTable = await _context.OrdersTable.FindAsync(id);
            if (ordersTable == null)
            {
                return NotFound();
            }
            return View(ordersTable);
        }

        // POST: OrdersTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,CustomerId,OrderStatus,OrderDate,RequiredDate,ShippedDate,StoreId,BrandId")] OrdersTable ordersTable)
        {
            if (id != ordersTable.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordersTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersTableExists(ordersTable.OrderId))
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
            return View(ordersTable);
        }

        // GET: OrdersTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrdersTable == null)
            {
                return NotFound();
            }

            var ordersTable = await _context.OrdersTable
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (ordersTable == null)
            {
                return NotFound();
            }

            return View(ordersTable);
        }

        // POST: OrdersTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrdersTable == null)
            {
                return Problem("Entity set 'SeaFoodStoreContext.OrdersTable'  is null.");
            }
            var ordersTable = await _context.OrdersTable.FindAsync(id);
            if (ordersTable != null)
            {
                _context.OrdersTable.Remove(ordersTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersTableExists(int id)
        {
          return (_context.OrdersTable?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
