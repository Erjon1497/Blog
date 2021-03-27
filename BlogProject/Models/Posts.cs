using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string Title { get; set; }
        [NotNull]
        public string Content { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public ICollection<Comments> PostComments { get; set; }
        public string Image { get; set; }
        public DateTime CreatedOn { get; set; }
        [NotMapped]
        public bool Liked { get; set; }

        public User User { get; set; }
    }
}
