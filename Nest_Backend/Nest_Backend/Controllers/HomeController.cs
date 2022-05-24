using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nest_Backend.DAL;
using Nest_Backend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nest_Backend.Controllers
{
    public class HomeController : Controller
    {
        readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Sliders =await _context.Sliders.ToListAsync(),
                Categories =await _context.Categories.ToListAsync(),
                Products =await _context.Products.Include(p=>p.ProductImgs).Include(p=>p. Categories).Take(10).ToListAsync()

            };
            return View(homeVM);
        }
    }
}
