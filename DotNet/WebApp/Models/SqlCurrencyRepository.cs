using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Models
{
    public class SqlCurrencyRepository : ICurrencyRepository
    {
        private readonly AppDbContext _context;

        public SqlCurrencyRepository(AppDbContext context)
        {
            this._context = context;
        }

        public Currency Add(Currency currency)
        {
            Currency curr = _context.Currencies.FirstOrDefault(m => m.CurrencyCode == currency.CurrencyCode);
            currency.Date = DateTime.Now;
            if (curr == null)
            {
                _context.Currencies.Add(currency);
                _context.SaveChanges();
            }
            return currency;
        }

        public Currency Delete(int id)
        {
            Currency curr = _context.Currencies.FirstOrDefault(m => m.ID == id);
            if (curr != null)
            {
                _context.Currencies.Remove(curr);
                _context.SaveChanges();
            }
            return curr;
        }

        public IEnumerable<Currency> GetAllCurrencies()
        {
            return _context.Currencies;
        }

        public Currency GetCurrency(int id)
        {
            return _context.Currencies.FirstOrDefault(m => m.ID == id);
        }

        public Currency GetCurrencyByCode(string currencyCode)
        {
            return _context.Currencies.FirstOrDefault(m => m.CurrencyCode == currencyCode);
        }

        public int GetOrderNum(int id)
        {
            return _context.Currencies.FirstOrDefault(m => m.ID == id).OrderNum;
        }

        public int GetOrderNumByCode(string currencyCode)
        {
            return _context.Currencies.FirstOrDefault(m => m.CurrencyCode == currencyCode).OrderNum;
        }

        public Currency Update(Currency currency)
        {
            currency.Date = DateTime.Now;
            var curr = _context.Currencies.Attach(currency);
            curr.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return currency;
        }
    }
}
