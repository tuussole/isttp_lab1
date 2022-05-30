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
    public class GamesController : Controller
    {
        private readonly ApplicationContext _context;

        public GamesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Game.Include(g => g.Group);
            return View(await applicationContext.ToListAsync());
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Game == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(g => g.Group)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.Set<Group>(), "Id", "Id");
            ViewData["AgeId"] = new SelectList(_context.Set<AgeCategory>(), "Id", "Id");
            ViewData["NOPId"] = new SelectList(_context.Set<NOPCategory>(), "Id", "Id");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,LeftQuantity,NOPId,AgeId,GroupId")] Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(_context.Set<Group>(), "Id", "Id", game.GroupId);
            ViewData["AgeId"] = new SelectList(_context.Set<AgeCategory>(), "Id", "Id", game.AgeId);
            ViewData["NOPId"] = new SelectList(_context.Set<NOPCategory>(), "Id", "Id", game.NOPId);
            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Game == null)
            {
                return NotFound();
            }

            var game = await _context.Game.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.Set<Group>(), "Id", "Id", game.GroupId);
            ViewData["AgeId"] = new SelectList(_context.Set<AgeCategory>(), "Id", "Id", game.AgeId);
            ViewData["NOPId"] = new SelectList(_context.Set<NOPCategory>(), "Id", "Id", game.NOPId);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,LeftQuantity,NOPId,AgeId,GroupId")] Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.Id))
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
            ViewData["GroupId"] = new SelectList(_context.Set<Group>(), "Id", "Id", game.GroupId);
            ViewData["AgeId"] = new SelectList(_context.Set<AgeCategory>(), "Id", "Id", game.AgeId);
            ViewData["NOPId"] = new SelectList(_context.Set<NOPCategory>(), "Id", "Id", game.NOPId);
            return View(game);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Game == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(g => g.Group)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Game == null)
            {
                return Problem("Entity set 'ApplicationContext.Game'  is null.");
            }
            var game = await _context.Game.FindAsync(id);
            if (game != null)
            {
                _context.Game.Remove(game);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
          return _context.Game.Any(e => e.Id == id);
        }
    }
}
