using Corporate.DAL;
using Corporate.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Corporate.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ClientsController : Controller
    {
        private AppDbContext _context { get; }
        private IWebHostEnvironment _env { get; }
        public ClientsController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Client> clients = await _context.Clients.ToListAsync();
            return View(clients);
        }
    }
}
