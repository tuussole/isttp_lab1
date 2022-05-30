using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoardGames.Models;

namespace BoardGames.Controllers
{
    public class NOPCategoriesController : Controller
    {
        private readonly ApplicationContext _context;

        public NOPCategoriesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: NOPCategories
        public async Task<IActionResult> Index()
        {
              return View(await _context.NOPCategory.ToListAsync());
        }

        // GET: NOPCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NOPCategory == null)
            {
                return NotFound();
            }

            var nOPCategory = await _context.NOPCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nOPCategory == null)
            {
                return NotFound();
            }

            return View(nOPCategory);
        }

        // GET: NOPCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NOPCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,From,To")] NOPCategory nOPCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nOPCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nOPCategory);
        }

        // GET: NOPCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NOPCategory == null)
            {
                return NotFound();
            }

            var nOPCategory = await _context.NOPCategory.FindAsync(id);
            if (nOPCategory == null)
            {
                return NotFound();
            }
            return View(nOPCategory);
        }

        // POST: NOPCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,From,To")] NOPCategory nOPCategory)
        {
            if (id != nOPCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nOPCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NOPCategoryExists(nOPCategory.Id))
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
            return View(nOPCategory);
        }

        // GET: NOPCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NOPCategory == null)
            {
                return NotFound();
            }

            var nOPCategory = await _context.NOPCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nOPCategory == null)
            {
                return NotFound();
            }

            return View(nOPCategory);
        }

        // POST: NOPCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NOPCategory == null)
            {
                return Problem("Entity set 'ApplicationContext.NOPCategory'  is null.");
            }
            var nOPCategory = await _context.NOPCategory.FindAsync(id);
            if (nOPCategory != null)
            {
                _context.NOPCategory.Remove(nOPCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NOPCategoryExists(int id)
        {
          return _context.NOPCategory.Any(e => e.Id == id);
        }
    }
}
