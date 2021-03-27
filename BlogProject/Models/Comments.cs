using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        [NotNull]
        public string Content { get; set; }
        public int LikeCount { get; set; }
        public DateTime CreatedOn { get; set; }


        public User User { get; set; }
        public Posts Post { get; set; }
    }
}
