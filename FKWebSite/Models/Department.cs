using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FKWebSite.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }
        public string Vision { get; set; }
        public string Slate { get; set; }
        public string DeptHead { get; set; }
        public string DeptHeadImg { get; set; }
        public int TeachersNum { get; set; }
        public string Quality { get; set; }
    }
}
