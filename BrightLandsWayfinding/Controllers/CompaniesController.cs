using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BrightLandsWayfinding.Data;
using BrightLandsWayfinding.Models.Companies;

namespace BrightLandsWayfinding.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly AppDbContext _context;

        public CompaniesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            var appDbContext = _context.Companies.Include(c => c.Room);
            return View(await appDbContext.ToListAsync());
        }
        public async Task<IActionResult> UserIndex()
        {
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            var appDbContext = _context.Companies.Include(c => c.Room);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Companies == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .Include(c => c.Room)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (company == null)
            {
                return NotFound();
            }
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            return View(company);
        }
        public async Task<IActionResult> UserDetails(int? id)
        {
            if (id == null || _context.Companies == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .Include(c => c.Room)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (company == null)
            {
                return NotFound();
            }
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name");
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,ProfileImage,TelephoneNumber,EmailAddress,WebsiteURL,RoomID")] Company company)
        {
            if (ModelState.IsValid)
            {
                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", company.RoomID);
            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Companies == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            ViewBag.Companies = _context.Companies;
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", company.RoomID);
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,ProfileImage,TelephoneNumber,EmailAddress,WebsiteURL,RoomID")] Company company)
        {
            if (id != company.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.ID))
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
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", company.RoomID);
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Companies == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .Include(c => c.Room)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (company == null)
            {
                return NotFound();
            }
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Companies == null)
            {
                return Problem("Entity set 'AppDbContext.Companies'  is null.");
            }
            var company = await _context.Companies.FindAsync(id);
            if (company != null)
            {
                _context.Companies.Remove(company);
            }
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
          return _context.Companies.Any(e => e.ID == id);
        }
    }
}
