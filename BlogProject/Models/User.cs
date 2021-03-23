using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Models
{
    public class User
    {
        public int Id { get; set; }
        [NotNull]
        public string Username { get; set; }
        [NotNull]
        public string Email { get; set; }
        [NotNull]
        public string Password { get; set; }

        public ICollection<Posts> UserPosts { get; set; }
    }
}
