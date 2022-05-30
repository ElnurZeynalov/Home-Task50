using Corporate.DAL;
using Corporate.Models;
using Corporate.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Corporate.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Slider = await _context.Slider.ToListAsync(),
                AboutCarts = await _context.AboutCarts.Take(4).ToListAsync(),
                PortfolioCategories = await _context.PortfolioCategories.ToListAsync(),
                PortfolioItems = await _context.PortfolioItems.ToListAsync(),
                ClientComments = await _context.ClientComments.ToListAsync(),
                Clients = await _context.Clients.ToListAsync(),
                Contacts = await _context.Contacts.ToListAsync(),
            };
            return View(homeVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
            return View();
        }
}
}
