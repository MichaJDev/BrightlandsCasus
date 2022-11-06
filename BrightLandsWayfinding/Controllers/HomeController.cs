using BrightLandsWayfinding.Data;
using BrightLandsWayfinding.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BrightLandsWayfinding.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Events = _context.Event;
            ViewBag.Buildings = _context.Buildings;
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            return View();
        }

        public IActionResult UserIndex()
        {
            ViewBag.Events = _context.Event;
            ViewBag.Buildings = _context.Buildings;
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.Events = _context.Event;
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            ViewBag.Events = _context.Event;
            ViewBag.Users = _context.User;
            ViewBag.Companies = _context.Companies;
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
