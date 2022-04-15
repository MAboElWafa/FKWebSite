using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FKWebSite.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public string Description { get; set; } 

    }
}
