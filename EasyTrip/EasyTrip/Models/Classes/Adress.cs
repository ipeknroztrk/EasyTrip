using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyTrip.Models.Classes
{
    public class Adress
    {
        [Key]
        public int AdressId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public string Telefon { get; set; }
        public string Location { get; set; }
    }
}