using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyTrip.Models.Classes
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Comments { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}