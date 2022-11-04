﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BrightLandsWayfinding.Data;
using BrightLandsWayfinding.Models.Users;

namespace BrightLandsWayfinding.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            var appDbContext = _context.User.Include(u => u.Company);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .Include(u => u.Company)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            ViewData["CompanyID"] = new SelectList(_context.Companies, "ID", "Name");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Prefix,Name,MiddleName,Surname,Suffix,EmailAddress,TelephoneNumber,DateOfBirth,Gender,UserType,Description,CompanyID")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            ViewData["CompanyID"] = new SelectList(_context.Companies, "ID", "Name", user.CompanyID);
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            ViewData["CompanyID"] = new SelectList(_context.Companies, "ID", "Name", user.CompanyID);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Prefix,Name,MiddleName,Surname,Suffix,EmailAddress,TelephoneNumber,DateOfBirth,Gender,UserType,Description,CompanyID")] User user)
        {
            if (id != user.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.ID))
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
            ViewData["CompanyID"] = new SelectList(_context.Companies, "ID", "Name", user.CompanyID);
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .Include(u => u.Company)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'AppDbContext.User'  is null.");
            }
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
            }
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return _context.User.Any(e => e.ID == id);
        }
    }
}
