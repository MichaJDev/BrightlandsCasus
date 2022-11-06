using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BrightLandsWayfinding.Data;
using BrightLandsWayfinding.Models.MapRoutes;

namespace BrightLandsWayfinding.Controllers
{
    public class MapRoutesController : Controller
    {
        private readonly AppDbContext _context;

        public MapRoutesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MapRoutes
        public async Task<IActionResult> Index()
        {
            ViewBag.Events = _context.Event.Where(m => m.EndTime >= DateTime.Now);
            ViewBag.Companies = _context.Companies;
            ViewBag.Users = _context.User;
            var appDbContext = _context.Routes.Include(m => m.EndLocation).Include(m => m.StartLocation);
            return View(await appDbContext.ToListAsync());
        }
        public async Task<IActionResult> UserIndex()
        {
            ViewBag.Events = _context.Event.Where(m => m.EndTime >= DateTime.Now);
            ViewBag.Companies = _context.Companies;
            ViewBag.Users = _context.User;
            var appDbContext = _context.Routes.Include(m => m.EndLocation).Include(m => m.StartLocation);
            return View(await appDbContext.ToListAsync());
        }
        // GET: MapRoutes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Routes == null)
            {
                return NotFound();
            }

            var mapRoute = await _context.Routes
                .Include(m => m.EndLocation)
                .Include(m => m.StartLocation)
                .Include(m => m.Steps)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mapRoute == null)
            {
                return NotFound();
            }
            ViewBag.Events = _context.Event.Where(m => m.EndTime >= DateTime.Now);
            ViewBag.Steps = _context.Step.Where(m => m.MapRouteID == id);
            ViewBag.Companies = _context.Companies;
            ViewBag.Users = _context.User;
            return View(mapRoute);
        }
        public async Task<IActionResult> UserDetails(int? id)
        {
            if (id == null || _context.Routes == null)
            {
                return NotFound();
            }

            var mapRoute = await _context.Routes
                .Include(m => m.EndLocation)
                .Include(m => m.StartLocation)
                .Include(m => m.Steps)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mapRoute == null)
            {
                return NotFound();
            }
            ViewBag.Events = _context.Event.Where(m => m.EndTime >= DateTime.Now);
            ViewBag.Steps = _context.Step.Where(m => m.MapRouteID == id);
            ViewBag.Companies = _context.Companies;
            ViewBag.Users = _context.User;
            return View(mapRoute);
        }
        // GET: MapRoutes/Create
        public IActionResult Create()
        {
            ViewData["EndLocationID"] = new SelectList(_context.Rooms, "ID", "Name");
            ViewData["StartLocationID"] = new SelectList(_context.Rooms, "ID", "Name");
           
            return View();
        }

        // POST: MapRoutes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description,StartLocationID,EndLocationID")] MapRoute mapRoute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mapRoute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Events = _context.Event.Where(m => m.EndTime >= DateTime.Now);
            ViewBag.Companies = _context.Companies;
            ViewBag.Users = _context.User;
            ViewData["EndLocationID"] = new SelectList(_context.Rooms, "ID", "Name", mapRoute.EndLocationID);
            ViewData["StartLocationID"] = new SelectList(_context.Rooms, "ID", "Name", mapRoute.StartLocationID);
            return View(mapRoute);
        }

        // GET: MapRoutes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Routes == null)
            {
                return NotFound();
            }

            var mapRoute = await _context.Routes.FindAsync(id);
            if (mapRoute == null)
            {
                return NotFound();
            }
            ViewBag.Events = _context.Event.Where(m => m.EndTime >= DateTime.Now);
            ViewBag.Companies = _context.Companies;
            ViewBag.Users = _context.User;
            ViewData["EndLocationID"] = new SelectList(_context.Rooms, "ID", "NAme", mapRoute.EndLocationID);
            ViewData["StartLocationID"] = new SelectList(_context.Rooms, "ID", "Name", mapRoute.StartLocationID);
            return View(mapRoute);
        }

        // POST: MapRoutes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description,StartLocationID,EndLocationID")] MapRoute mapRoute)
        {
            if (id != mapRoute.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mapRoute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MapRouteExists(mapRoute.ID))
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
            ViewBag.Events = _context.Event.Where(m => m.EndTime >= DateTime.Now);
            ViewBag.Companies = _context.Companies;
            ViewBag.Users = _context.User;
            ViewData["EndLocationID"] = new SelectList(_context.Rooms, "ID", "NAme", mapRoute.EndLocationID);
            ViewData["StartLocationID"] = new SelectList(_context.Rooms, "ID", "Name", mapRoute.StartLocationID);
            return View(mapRoute);
        }

        // GET: MapRoutes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Routes == null)
            {
                return NotFound();
            }

            var mapRoute = await _context.Routes
                .Include(m => m.EndLocation)
                .Include(m => m.StartLocation)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mapRoute == null)
            {
                return NotFound();
            }
            ViewBag.Events = _context.Event.Where(m => m.EndTime >= DateTime.Now);
            ViewBag.Companies = _context.Companies;
            ViewBag.Users = _context.User;
            return View(mapRoute);
        }

        // POST: MapRoutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Routes == null)
            {
                return Problem("Entity set 'AppDbContext.Routes'  is null.");
            }
            var mapRoute = await _context.Routes.FindAsync(id);
            if (mapRoute != null)
            {
                _context.Routes.Remove(mapRoute);
            }
            ViewBag.Events = _context.Event.Where(m => m.EndTime >= DateTime.Now);
            ViewBag.Companies = _context.Companies;
            ViewBag.Users = _context.User;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MapRouteExists(int id)
        {
          return _context.Routes.Any(e => e.ID == id);
        }
    }
}
