using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public interface ICurrencyRepository
    {
        Currency GetCurrency(int id);
        IEnumerable<Currency> GetAllCurrencies();
        Currency Add(Currency currency);
        Currency Update(Currency currency);
        Currency Delete(int id);
        decimal GetRateByCurrencies(string fromCurrency, string toCurrency);
        public List<string> GetUniqueCurrencies();
    }
}
