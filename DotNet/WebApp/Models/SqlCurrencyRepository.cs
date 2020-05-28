using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            Currency curr = _context.Currensies.FirstOrDefault(m => m.CurrencyName == currency.CurrencyName);
            currency.Date = DateTime.Now;
            if (curr == null)
            {
                _context.Currensies.Add(currency);
                _context.SaveChanges();
            } else
            {
                currency.Date = DateTime.Now;
                this.Update(currency);
            }
            return currency;
        }

        public Currency Delete(int id)
        {
            Currency curr = _context.Currensies.FirstOrDefault(m => m.ID == id);
            if (curr != null)
            {
                _context.Currensies.Remove(curr);
                _context.SaveChanges();
            }
            return curr;
        }

        public IEnumerable<Currency> GetAllCurrencies()
        {
            return _context.Currensies;
        }

        public Currency GetCurrency(int id)
        {
            return _context.Currensies.FirstOrDefault(m => m.ID == id);
        }

        public decimal GetBuyRateByCurrencies(string currName)
        {
            Currency curr = _context.Currensies.FirstOrDefault(x => x.CurrencyName == currName);
            if (curr != null) return curr.Buy;
            return (decimal)0.0;
        }

        public decimal GetSellRateByCurrencies(string currName)
        {
            Currency curr = _context.Currensies.FirstOrDefault(x => x.CurrencyName == currName);
            if (curr != null) return curr.Sell;
            return (decimal)0.0;
        }

        public Currency Update(Currency currency)
        {
            currency.Date = DateTime.Now;
            var curr = _context.Currensies.Attach(currency);
            curr.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return currency;
        }

        public List<string> GetUniqueCurrencies()
        {
            HashSet<string> st = new HashSet<string>();
            foreach (var item in _context.Currensies)
            {
                st.Add(item.CurrencyName);
            }
            return st.ToList();
        }
    }
}
