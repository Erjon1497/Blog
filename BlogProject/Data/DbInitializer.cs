//using BlogProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BlogContext context)
        {
            context.Database.EnsureCreated();
            // Look for any users.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }
            var postUser = new Models.User();
            var users = new Models.User[]
            {
            new Models.User{Username="Admin",Email="admin@test.com",Password="admin"}
            };
            foreach (Models.User u in users)
            {
                postUser = u;
                context.Users.Add(u);
            }
            context.SaveChanges();

            var posts = new Models.Posts[]
            {
            new Models.Posts{UserId=1, Title="This is a sample post", Content="This is some sample content! This is some sample content! " +
            "This is some sample content! This is some sample content! This is some sample content! This is some sample content! This is some sample content! " +
            "This is some sample content! This is some sample content! This is some sample content! This is some sample content! This is some sample content! ",
                User = postUser, Image="https://mdbootstrap.com/img/Photos/Slides/img%20(142).jpg", CreatedOn=DateTime.Now}
            };
            foreach (Models.Posts p in posts)
            {
                context.Posts.Add(p);
            }
            context.SaveChanges();
        }
    }
}
