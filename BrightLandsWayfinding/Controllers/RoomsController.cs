using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BrightLandsWayfinding.Data;
using BrightLandsWayfinding.Models.Rooms;

namespace BrightLandsWayfinding.Controllers
{
    public class RoomsController : Controller
    {
        private readonly AppDbContext _context;

        public RoomsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            var appDbContext = _context.Rooms.Include(r => r.Story);
            return View(await appDbContext.ToListAsync());
        }
        public async Task<IActionResult> UserIndex()
        {
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            var appDbContext = _context.Rooms.Include(r => r.Story);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.Story)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (room == null)
            {
                return NotFound();
            }
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            return View(room);
        }
        public async Task<IActionResult> UserDetails(int? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.Story)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (room == null)
            {
                return NotFound();
            }
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            ViewData["StoryID"] = new SelectList(_context.Stories, "ID", "Name");
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,StoryID,Type")] Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            ViewData["StoryID"] = new SelectList(_context.Stories, "ID", "Name", room.StoryID);
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            ViewData["StoryID"] = new SelectList(_context.Stories, "ID", "Name", room.StoryID);
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,StoryID,Type")] Room room)
        {
            if (id != room.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.ID))
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
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            ViewData["StoryID"] = new SelectList(_context.Stories, "ID", "Name", room.StoryID);
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.Story)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (room == null)
            {
                return NotFound();
            }
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rooms == null)
            {
                return Problem("Entity set 'AppDbContext.Rooms'  is null.");
            }
            var room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
            }
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
          return _context.Rooms.Any(e => e.ID == id);
        }
    }
}
