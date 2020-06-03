using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
            List<Currency> currencies = _currencyRepository.GetAllCurrencies().ToList().OrderBy(x => x.OrderNum).ToList();
            return View(currencies);
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
                Currency curr = _currencyRepository.GetCurrencyByCode(currency.CurrencyCode);
                if (curr == null)
                {
                    _currencyRepository.Add(currency);
                    return RedirectToAction("Index", "Currency");
                } else
                {
                    ViewData["CurrencyAddAlert"] = "Such currency already exists";
                    Currency newCurr = new Currency();
                    return View(newCurr);
                }
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
