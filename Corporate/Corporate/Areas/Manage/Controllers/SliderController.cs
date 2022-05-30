using Corporate.DAL;
using Corporate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corporate.Utilies.File;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Corporate.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SliderController : Controller
    {
        private AppDbContext _context { get;}
        private IWebHostEnvironment _env { get; }
        public SliderController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Slider.ToListAsync();
            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            bool isExist = _context.Slider.Any(x => x.Title.ToLower().Trim() == slider.Title.ToLower().Trim());
            if (isExist) return View();
            if (slider.Photo.CheckSize(900))
            {
                ModelState.AddModelError("Photo", "900 kb boyuk file yukleme bilmez");
                return View();
            }
            if (!slider.Photo.CheckType("image/"))
            {
                ModelState.AddModelError("Photo", "Yalniz image formatinda sekil yuklenmelidir");
                return View();
            }
            slider.Image = await slider.Photo.SaveFileAsync(Path.Combine(_env.WebRootPath, "assets", "img"));
            await _context.Slider.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Slider slider = _context.Slider.Find(id);
            if (slider == null) return NotFound();
            _context.Slider.Remove(slider);
            _context.SaveChanges();
            FileExtension.DeleteSlideItem(Path.Combine(_env.WebRootPath, "assets", "img" , slider.Image));
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            Slider slider = _context.Slider.Find(id);
            if(slider == null) return NotFound();
            return View(slider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Slider slider)
        {
            if (slider.Id != id) return BadRequest();
            if (!slider.Photo.CheckType("image/"))
            {
                ModelState.AddModelError("Photo", "Yalniz image yuklenmelidir");
                return View();
            }
            if (slider.Photo.CheckSize(900))
            {
                ModelState.AddModelError("Photo", "900kb boyuk image yuklene bilmez");
                return View();
            }
            Slider sliderItem = _context.Slider.Find(id);
            sliderItem.Title = slider.Title;
            sliderItem.Text = slider.Text;
            sliderItem.Button1Text = slider.Button1Text;
            sliderItem.Button2Text = slider.Button2Text;
            sliderItem.Button1Url = slider.Button1Url;
            sliderItem.Button2Url = slider.Button2Url;
            slider.Image = await slider.Photo.SaveFileAsync(Path.Combine(_env.WebRootPath, "assets", "img"));
            sliderItem.Image = slider.Image;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
