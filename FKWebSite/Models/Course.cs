using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FKWebSite.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string PDFs { get; set; }
        public string Videos { get; set; }
        public string Date { get; set; }
        public string Reference { get; set; }

        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }
    }
}
