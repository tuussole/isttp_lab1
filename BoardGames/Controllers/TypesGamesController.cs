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
    public class TypesGamesController : Controller
    {
        private readonly ApplicationContext _context;

        public TypesGamesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: TypesGames
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.TypeGame.Include(t => t.Game);
            return View(await applicationContext.ToListAsync());
        }

        // GET: TypesGames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypeGame == null)
            {
                return NotFound();
            }

            var typeGame = await _context.TypeGame
                .Include(t => t.Game)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeGame == null)
            {
                return NotFound();
            }

            return View(typeGame);
        }

        // GET: TypesGames/Create
        public IActionResult Create()
        {
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "Id");
            ViewData["TypeId"] = new SelectList(_context.Game, "Id", "Id"); //?
            return View();
        }

        // POST: TypesGames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeId,GameId")] TypeGame typeGame)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeGame);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "Id", typeGame.GameId);
            ViewData["TypeId"] = new SelectList(_context.Game, "Id", "Id", typeGame.TypeId); //?
            return View(typeGame);
        }

        // GET: TypesGames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypeGame == null)
            {
                return NotFound();
            }

            var typeGame = await _context.TypeGame.FindAsync(id);
            if (typeGame == null)
            {
                return NotFound();
            }
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "Id", typeGame.GameId);
            ViewData["TypeId"] = new SelectList(_context.Game, "Id", "Id", typeGame.TypeId); //?
            return View(typeGame);
        }

        // POST: TypesGames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeId,GameId")] TypeGame typeGame)
        {
            if (id != typeGame.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeGame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeGameExists(typeGame.Id))
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
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "Id", typeGame.GameId);
            ViewData["TypeId"] = new SelectList(_context.Game, "Id", "Id", typeGame.TypeId); //?
            return View(typeGame);
        }

        // GET: TypesGames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypeGame == null)
            {
                return NotFound();
            }

            var typeGame = await _context.TypeGame
                .Include(t => t.Game)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeGame == null)
            {
                return NotFound();
            }

            return View(typeGame);
        }

        // POST: TypesGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypeGame == null)
            {
                return Problem("Entity set 'ApplicationContext.TypeGame'  is null.");
            }
            var typeGame = await _context.TypeGame.FindAsync(id);
            if (typeGame != null)
            {
                _context.TypeGame.Remove(typeGame);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeGameExists(int id)
        {
          return _context.TypeGame.Any(e => e.Id == id);
        }
    }
}
