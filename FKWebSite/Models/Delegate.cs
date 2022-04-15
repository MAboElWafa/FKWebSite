using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FKWebSite.Models
{
    public class Delegate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Department { get; set; }
        public string Year { get; set; }
        public string Contact { get; set; }
        public string Quote { get; set; }


        [NotMapped]
        public IFormFile File { get; set; }

        
    }
}
