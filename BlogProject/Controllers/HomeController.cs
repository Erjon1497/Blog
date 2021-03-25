using BlogProject.Data;
using BlogProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BlogContext _context;

        public HomeController(ILogger<HomeController> logger,
            BlogContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {
            User user = new User();

            if (id == 0 || id == null)
            {
                return View(user);
                
            }
            else
            {
                user = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
                if (user != null) user.LoggedIn = true;
                return View(user);
            }
                
           
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
