using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BrightLandsWayfinding.Data;
using BrightLandsWayfinding.Models.Steps;

namespace BrightLandsWayfinding.Controllers
{
    public class StepsController : Controller
    {
        private readonly AppDbContext _context;

        public StepsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Steps
        public async Task<IActionResult> Index()
        {
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            var appDbContext = _context.Step.Include(s => s.Room);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Steps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Step == null)
            {
                return NotFound();
            }

            var step = await _context.Step
                .Include(s => s.Room)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (step == null)
            {
                return NotFound();
            }
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            return View(step);
        }

        // GET: Steps/Create
        public IActionResult Create()
        {
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name");
            return View();
        }

        // POST: Steps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description,RoomID")] Step step)
        {
            if (ModelState.IsValid)
            {
                _context.Add(step);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", step.RoomID);
            return View(step);
        }

        // GET: Steps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Step == null)
            {
                return NotFound();
            }

            var step = await _context.Step.FindAsync(id);
            if (step == null)
            {
                return NotFound();
            }
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", step.RoomID);
            return View(step);
        }

        // POST: Steps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description,RoomID")] Step step)
        {
            if (id != step.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(step);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StepExists(step.ID))
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
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", step.RoomID);
            return View(step);
        }

        // GET: Steps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Step == null)
            {
                return NotFound();
            }

            var step = await _context.Step
                .Include(s => s.Room)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (step == null)
            {
                return NotFound();
            }
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            return View(step);
        }

        // POST: Steps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Step == null)
            {
                return Problem("Entity set 'AppDbContext.Step'  is null.");
            }
            var step = await _context.Step.FindAsync(id);
            if (step != null)
            {
                _context.Step.Remove(step);
            }
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StepExists(int id)
        {
          return _context.Step.Any(e => e.ID == id);
        }
    }
}
