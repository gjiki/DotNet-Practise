using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CalculatorController : Controller
    {
        private IOperationRepository _operationRepository;
        private ICourseRepository _courseRepository;
        private ICurrencyRepository _currencyRepository;

        public CalculatorController(IOperationRepository operationRepository, ICourseRepository courseRepository, ICurrencyRepository currencyRepository)
        {
            _operationRepository = operationRepository;
            _courseRepository = courseRepository;
            _currencyRepository = currencyRepository;
        }

        public IActionResult Index()
        {
            var model = _operationRepository.GetAllOperations();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<string> lst = new List<string>();
            foreach (var item in _courseRepository.GetUniqueCurrencies())
            {
                lst.Add(item);
            }
            ViewBag.UniqueCurrenciesFromCalculator = new SelectList(lst);

            Operation operation = new Operation();
            return View(operation);
        }

        [HttpPost]
        public IActionResult Add(Operation operation)
        {
            if (ModelState.IsValid)
            {
                _operationRepository.Add(operation);
                return RedirectToAction("Index", "Calculator");
            }
            return View(operation);
        }

        [HttpPost]
        public JsonResult Rate(string fromCurrency, string toCurrency)
        {
            decimal buyFirst = _courseRepository.GetBuyRateByCurrencyName(fromCurrency);
            decimal sellSecond = _courseRepository.GetSellRateByCurrencyName(toCurrency);

            var result = buyFirst / sellSecond;
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetRate(string fromCurrency)
        {
            return Json(_courseRepository.GetBuyRateByCurrencyName(fromCurrency));
        }
    }
}