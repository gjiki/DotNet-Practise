using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public interface ICurrencyRepository
    {
        Currency GetCurrency(int Id);
        IEnumerable<Currency> GetAllCurrencies();
        Currency Add(Currency currency);
        Currency Update(Currency currency);
        Currency Delete(int Id);
    }
}
