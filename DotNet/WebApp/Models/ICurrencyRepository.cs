using System.Collections.Generic;

namespace WebApp.Models
{
    public interface ICurrencyRepository
    {
        Currency GetCurrency(int id);
        Currency GetCurrencyByCode(string currencyCode);
        IEnumerable<Currency> GetAllCurrencies();
        Currency Add(Currency currency);
        Currency Update(Currency currency);
        Currency Delete(int id);
        int GetOrderNum(int id);
        int GetOrderNumByCode(string currencyCode);

    }
}
