using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Models
{
    public class Posts
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [NotNull]
        public string Content { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public ICollection<Comments> PostComments { get; set; }

        public User User { get; set; }
    }
}
