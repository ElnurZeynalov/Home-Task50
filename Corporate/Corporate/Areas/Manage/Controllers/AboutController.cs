using Corporate.DAL;
using Corporate.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corporate.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AboutController : Controller
    {
        private AppDbContext _context { get;}
        private IWebHostEnvironment _env;
        public AboutController(AppDbContext context ,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<AboutCarts> aboutCarts = await _context.AboutCarts.ToListAsync();
            return View(aboutCarts);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AboutCarts aboutCarts)
        {
            bool isExist = _context.AboutCarts.Any(x => x.CartTitle.ToLower().Trim() == aboutCarts.CartTitle.ToLower().Trim());
            if (isExist)
            {
                ModelState.AddModelError("Title", "Bu adda cart movcuddur");
                return View();
            }
            await _context.AboutCarts.AddAsync(aboutCarts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            AboutCarts aboutcarts = _context.AboutCarts.Find(id);
            if (aboutcarts == null) return NotFound();
            _context.AboutCarts.Remove(aboutcarts);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            AboutCarts aboutCarts = _context.AboutCarts.Find(id);
            if(aboutCarts == null) return NotFound();
            return View(aboutCarts);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id , AboutCarts aboutCarts)
        {
            if(aboutCarts.Id != id) return BadRequest();
            AboutCarts aboutItem = _context.AboutCarts.Find(id);
            aboutItem.CartDescription = aboutCarts.CartDescription;
            aboutItem.CartTitle = aboutCarts.CartTitle;
            aboutItem.CartIcon = aboutCarts.CartIcon;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
