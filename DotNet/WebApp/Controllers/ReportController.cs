using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ReportController : Controller
    {
        private IOperationRepository _operationRepository;
        private ICourseRepository _courseRepository;

        public ReportController(IOperationRepository operationRepository, ICourseRepository courseRepository)
        {
            _operationRepository = operationRepository;
            _courseRepository = courseRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Search()
        {
            Period period = new Period();
            return View(period);
        }

        [HttpPost]
        public IActionResult Search(Period period)
        {
            List <Operation> filteredByDate = _operationRepository.GetAllOperations().Where(x => x.Date >= period.StartDate && x.Date <= period.EndDate).ToList();
            ViewBag.StartDate = period.StartDate;
            ViewBag.EndDate = period.EndDate;
            return View("SearchResults", filteredByDate);
        }

        [HttpGet]
        public IActionResult Suspicios()
        {
            return View(_operationRepository.GetAllOperations().OrderBy(x => x.SellAmount * _courseRepository.GetBuyRateByCurrencyName(x.FromCurrency)).Take(5));
        }
    }
}