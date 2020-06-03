using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace WebApp.Controllers
{
    public class CourseController : Controller
    {
        private ICourseRepository _courseRepository;
        private ICurrencyRepository _currencyRepository;

        public CourseController(ICourseRepository courseRepository, ICurrencyRepository currencyRepository)
        {
            _courseRepository = courseRepository;
            _currencyRepository = currencyRepository;
        }

        public IActionResult Index()
        {
            var model = _courseRepository.GetAllCourses();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<string> lst = new List<string>();
            foreach (var item in _currencyRepository.GetAllCurrencies().ToList().OrderBy(x => x.OrderNum).ToList())
            {
                lst.Add(item.CurrencyCode);
            }
            ViewBag.UniqueCurrenciesFromCourse = new SelectList(lst);

            Course course = new Course();
            return View(course);
        }

        [HttpPost]
        public IActionResult Add(Course course)
        {
            if (ModelState.IsValid)
            {
                Course currCourse = _courseRepository.GetCourseByCurrencyName(course.CurrencyName);
                if (currCourse == null)
                {
                    _courseRepository.Add(course);
                    return RedirectToAction("Index", "Course");
                } else
                {
                    ViewData["CourseAlrert"] = "Course already exists";
                    List<string> lst = new List<string>();
                    foreach (var item in _currencyRepository.GetAllCurrencies().ToList().OrderBy(x => x.OrderNum).ToList())
                    {
                        lst.Add(item.CurrencyCode);
                    }
                    ViewBag.UniqueCurrenciesFromCourse = new SelectList(lst);

                    Course newCourse = new Course();
                    return View(newCourse);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Course curr = _courseRepository.GetCourse(id);
            return View(curr);
        }

        [HttpPost]
        public IActionResult Edit(Course currency)
        {
            if (ModelState.IsValid)
            {
                _courseRepository.Update(currency);
                return RedirectToAction("Index", "Course");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _courseRepository.Delete(id);
            return RedirectToAction("Index", "Course");
        }
    }
}