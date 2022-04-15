using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FKWebSite.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Quote { get; set; }
        public string Email { get; set; }



        [NotMapped]
        public IFormFile Docs { get; set; }

        public List<Course> Course { get; set; }
        public List<File> File { get; set; }

    }
}
