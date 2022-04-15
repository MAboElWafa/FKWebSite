using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FKWebSite.Models
{
    public class Suggestion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Image { get; set; }
        public string Place { get; set; }
        public int Hours { get; set; }
        public string Link { get; set; }


        [NotMapped]
        public IFormFile File { get; set; }
    }
}
