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
    public class TypesController : Controller
    {
        private readonly ApplicationContext _context;

        public TypesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Types
        public async Task<IActionResult> Index()
        {
              return View(await _context.GameType.ToListAsync());
        }

        // GET: Types/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GameType == null)
            {
                return NotFound();
            }

            var gameType = await _context.GameType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameType == null)
            {
                return NotFound();
            }

            return View(gameType);
        }

        // GET: Types/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Types/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Name")] GameType gameType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gameType);
        }

        // GET: Types/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GameType == null)
            {
                return NotFound();
            }

            var gameType = await _context.GameType.FindAsync(id);
            if (gameType == null)
            {
                return NotFound();
            }
            return View(gameType);
        }

        // POST: Types/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Name")] GameType gameType)
        {
            if (id != gameType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameTypeExists(gameType.Id))
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
            return View(gameType);
        }

        // GET: Types/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GameType == null)
            {
                return NotFound();
            }

            var gameType = await _context.GameType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameType == null)
            {
                return NotFound();
            }

            return View(gameType);
        }

        // POST: Types/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GameType == null)
            {
                return Problem("Entity set 'ApplicationContext.GameType'  is null.");
            }
            var gameType = await _context.GameType.FindAsync(id);
            if (gameType != null)
            {
                _context.GameType.Remove(gameType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameTypeExists(int id)
        {
          return _context.GameType.Any(e => e.Id == id);
        }
    }
}
