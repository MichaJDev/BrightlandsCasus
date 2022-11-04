using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BrightLandsWayfinding.Data;
using BrightLandsWayfinding.Models.Buildings;

namespace BrightLandsWayfinding.Controllers
{
    public class BuildingsController : Controller
    {
        private readonly AppDbContext _context;

        public BuildingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Buildings
        public async Task<IActionResult> Index()
        {
            ViewBag.Companies = _context.Companies;
            ViewBag.Users = _context.User;
            return View(await _context.Buildings.Include(m => m.Stories).ToListAsync());
        }

        // GET: Buildings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Buildings == null)
            {
                return NotFound();
            }

            var building = await _context.Buildings.Include(b => b.Stories)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (building == null)
            {
                return NotFound();
            }
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            return View(building);
        }

        // GET: Buildings/Create
        public IActionResult Create()
        {
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            return View();
        }

        // POST: Buildings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Address,PostalCode,City,Region,Country")] Building building)
        {
            if (ModelState.IsValid)
            {
                _context.Add(building);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            return View(building);
        }

        // GET: Buildings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Buildings == null)
            {
                return NotFound();
            }

            var building = await _context.Buildings.FindAsync(id);
            
            if (building == null)
            {
                return NotFound();
            }
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            return View(building);
        }

        // POST: Buildings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Address,PostalCode,City,Region,Country")] Building building)
        {
            if (id != building.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(building);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildingExists(building.ID))
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
            return View(building);
        }

        // GET: Buildings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Buildings == null)
            {
                return NotFound();
            }

            var building = await _context.Buildings
                .FirstOrDefaultAsync(m => m.ID == id);
            if (building == null)
            {
                return NotFound();
            }
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            return View(building);
        }

        // POST: Buildings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Buildings == null)
            {
                return Problem("Entity set 'AppDbContext.Buildings'  is null.");
            }
            var building = await _context.Buildings.FindAsync(id);
            if (building != null)
            {
                _context.Buildings.Remove(building);
            }
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuildingExists(int id)
        {
          return _context.Buildings.Any(e => e.ID == id);
        }
    }
}
