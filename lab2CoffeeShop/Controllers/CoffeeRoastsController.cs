using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab2CoffeeShop.Models;

namespace lab2CoffeeShop.Controllers
{
    public class CoffeeRoastsController : Controller
    {
        private readonly DbcoffeeShopContext _context;

        public CoffeeRoastsController(DbcoffeeShopContext context)
        {
            _context = context;
        }

        // GET: CoffeeRoasts
        public async Task<IActionResult> Index()
        {
              return _context.CoffeeRoasts != null ? 
                          View(await _context.CoffeeRoasts.ToListAsync()) :
                          Problem("Entity set 'DbcoffeeShopContext.CoffeeRoasts'  is null.");
        }

        // GET: CoffeeRoasts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CoffeeRoasts == null)
            {
                return NotFound();
            }

            var coffeeRoast = await _context.CoffeeRoasts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coffeeRoast == null)
            {
                return NotFound();
            }

            return View(coffeeRoast);
        }

        // GET: CoffeeRoasts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CoffeeRoasts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CoffeeRoast coffeeRoast)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coffeeRoast);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coffeeRoast);
        }

        // GET: CoffeeRoasts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CoffeeRoasts == null)
            {
                return NotFound();
            }

            var coffeeRoast = await _context.CoffeeRoasts.FindAsync(id);
            if (coffeeRoast == null)
            {
                return NotFound();
            }
            return View(coffeeRoast);
        }

        // POST: CoffeeRoasts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CoffeeRoast coffeeRoast)
        {
            if (id != coffeeRoast.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coffeeRoast);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoffeeRoastExists(coffeeRoast.Id))
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
            return View(coffeeRoast);
        }

        // GET: CoffeeRoasts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CoffeeRoasts == null)
            {
                return NotFound();
            }

            var coffeeRoast = await _context.CoffeeRoasts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coffeeRoast == null)
            {
                return NotFound();
            }

            return View(coffeeRoast);
        }

        // POST: CoffeeRoasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CoffeeRoasts == null)
            {
                return Problem("Entity set 'DbcoffeeShopContext.CoffeeRoasts'  is null.");
            }
            var coffeeRoast = await _context.CoffeeRoasts.FindAsync(id);
            if (coffeeRoast != null)
            {
                _context.CoffeeRoasts.Remove(coffeeRoast);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoffeeRoastExists(int id)
        {
          return (_context.CoffeeRoasts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
