using FKWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FKWebSite.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        FKContext db;
        public HomeController(FKContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            ViewBag.Suggestion = db.Suggestions.ToList();


            var result = db.Quotes.ToList();
            return View(result);
        }



        public IActionResult AllDepartments()
        {
            var result = db.Departments.ToList();
            return View(result);
        }


        public IActionResult DepartmentDetails(int id)
        {
            var result = db.Departments.Where(y => y.Id == id).ToList();
            return View(result);
        }



        public IActionResult AllTeachers()
        {
            var result = db.Doctors.ToList();
            return View(result);
        }


        public IActionResult Teacher(int id)
        {
            Doctor x = db.Doctors.Find(id);
            ViewData["DocImage"] = x.Image;

            Doctor y = db.Doctors.Find(id);
            ViewData["DocName"] = y.Name;

            Doctor z = db.Doctors.Find(id);
            ViewData["DocQuote"] = z.Quote;

            ViewBag.File = db.Files.ToList();


            var result = db.Courses.Where(y => y.DoctorId == id).ToList();
            return View(result);
        }


        public IActionResult Delegates()
        {

            ViewBag.D2021 = db.Delegates.Where(s => s.Year == "2021").ToList();
            ViewBag.D2020 = db.Delegates.Where(s =>s.Year == "2020").ToList();
            ViewBag.D2019 = db.Delegates.Where(s =>s.Year == "2019").ToList();
            ViewBag.D2018 = db.Delegates.Where(s =>s.Year == "2018").ToList();
            ViewBag.D2017 = db.Delegates.Where(s =>s.Year == "2017").ToList();


            //Delegate z = db.Delegates.Where(s =>s.Year == 2020);
            //ViewData["DocQuote"] = z.Quote;


            //var result = db.Delegates.ToList();

            return View();
        }


        public IActionResult CreateYourTable()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Teacher = db.Memorys.Where(s => s.Type == "Teacher").ToList();
            ViewBag.Student = db.Memorys.Where(s => s.Type == "Student").ToList();
            return View();
        }

        public IActionResult RecommendedTable()
        {
            var result = db.RecommendedTBs.ToList();
            return View(result);
        }


        public IActionResult Contact()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Contact(Contact model)
        {
            db.Contacts.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public  IActionResult AllCourses (string SearchCourses, int id)
        {
            var result = db.Courses.Where(s => s.Code.Contains(SearchCourses)
            || s.Name.Contains(SearchCourses)
            || s.Doctor.Name.Contains(SearchCourses));



          
            return View(result);
        }

        //public IActionResult AllCourses(String SearchCourses)
        //{

        //    var result = db.Courses.ToList();

        //    if (!String.IsNullOrEmpty(SearchCourses))
        //    {
        //        FKContext.Where(x => x.Code);
        //    }
        //    return View();
        //}



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
