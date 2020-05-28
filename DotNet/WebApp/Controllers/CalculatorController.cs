using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CalculatorController : Controller
    {
        private IOperationRepository _operationRepository;
        private ICurrencyRepository _currencyRepository;

        public CalculatorController(IOperationRepository operationRepository, ICurrencyRepository currencyRepository)
        {
            _operationRepository = operationRepository;
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
            lst.Add(null);
            foreach (var item in _currencyRepository.GetUniqueCurrencies())
            {
                lst.Add(item);
            }
            ViewBag.UniqueCurrencies = new SelectList(lst);

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
            return View();
        }

        [HttpPost]
        public JsonResult Rate(Operation data)
        {
            var result = new Random().Next(2, 4);
            return Json(result);
        }
    }
}