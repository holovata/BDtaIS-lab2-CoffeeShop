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
    public class CoffeeTypesController : Controller
    {
        private readonly DbcoffeeShopContext _context;

        public CoffeeTypesController(DbcoffeeShopContext context)
        {
            _context = context;
        }

        // GET: CoffeeTypes
        public async Task<IActionResult> Index()
        {
              return _context.CoffeeTypes != null ? 
                          View(await _context.CoffeeTypes.ToListAsync()) :
                          Problem("Entity set 'DbcoffeeShopContext.CoffeeTypes'  is null.");
        }

        // GET: CoffeeTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CoffeeTypes == null)
            {
                return NotFound();
            }

            var coffeeType = await _context.CoffeeTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coffeeType == null)
            {
                return NotFound();
            }

            return View(coffeeType);
        }

        // GET: CoffeeTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CoffeeTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CoffeeType coffeeType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coffeeType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coffeeType);
        }

        // GET: CoffeeTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CoffeeTypes == null)
            {
                return NotFound();
            }

            var coffeeType = await _context.CoffeeTypes.FindAsync(id);
            if (coffeeType == null)
            {
                return NotFound();
            }
            return View(coffeeType);
        }

        // POST: CoffeeTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CoffeeType coffeeType)
        {
            if (id != coffeeType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coffeeType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoffeeTypeExists(coffeeType.Id))
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
            return View(coffeeType);
        }

        // GET: CoffeeTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CoffeeTypes == null)
            {
                return NotFound();
            }

            var coffeeType = await _context.CoffeeTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coffeeType == null)
            {
                return NotFound();
            }

            return View(coffeeType);
        }

        // POST: CoffeeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CoffeeTypes == null)
            {
                return Problem("Entity set 'DbcoffeeShopContext.CoffeeTypes'  is null.");
            }
            var coffeeType = await _context.CoffeeTypes.FindAsync(id);
            if (coffeeType != null)
            {
                _context.CoffeeTypes.Remove(coffeeType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoffeeTypeExists(int id)
        {
          return (_context.CoffeeTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
