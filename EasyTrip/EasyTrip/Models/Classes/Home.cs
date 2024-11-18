using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyTrip.Models.Classes
{
    public class Home
    
    {
        [Key]
        public int HomeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}