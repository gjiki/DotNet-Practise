using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CurrencyController : Controller
    {
        private ICurrencyRepository _currencyRepository;

        public CurrencyController(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public IActionResult Index()
        {
            var model = _currencyRepository.GetAllCurrencies();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            Currency curr = new Currency();
            return View(curr);
        }

        [HttpPost]
        public IActionResult Add(Currency currency)
        {
            if (ModelState.IsValid)
            {
                _currencyRepository.Add(currency);
                return RedirectToAction("Index", "Currency");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Currency curr = _currencyRepository.GetCurrency(id);
            return View(curr);
        }

        [HttpPost]
        public IActionResult Edit(Currency currency)
        {
            if (ModelState.IsValid)
            {
                _currencyRepository.Update(currency);
                return RedirectToAction("Index", "Currency");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _currencyRepository.Delete(id);
            return RedirectToAction("Index", "Currency");
        }
    }
}