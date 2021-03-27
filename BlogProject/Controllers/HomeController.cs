using BlogProject.Data;
using BlogProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public async Task<IActionResult> Index()
        {
            List<Comments> comments = new List<Comments>();
            BlogProject.Startup.allPosts = await _context.Posts.ToListAsync();
            foreach(Posts p in BlogProject.Startup.allPosts)
            {
                if(p.CommentCount > 0)
                {
                    comments = await _context.Comments.Where(c => c.PostId == p.Id).ToListAsync();
                }
                BlogProject.Startup.allPosts.Where(allP => allP.Id == p.Id).FirstOrDefault().PostComments = comments;
            }
            BlogProject.Startup.allusers = await _context.Users.ToListAsync();

            return View();  
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,PostId,Content,LikeCount")] Comments comments)
        {
            comments.CreatedOn = DateTime.Now;
            comments.LikeCount = 0;
            _context.Add(comments);
            await _context.SaveChangesAsync();
            Posts posts = new Posts();
            posts = BlogProject.Startup.allPosts.Where(p => p.Id == comments.PostId).FirstOrDefault();
            posts.CommentCount += 1;
            try
            {
                _context.Update(posts);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();     
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
