using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class SqlCurrencyRepository : ICurrencyRepository
    {
        private readonly AppDbContext context;

        public SqlCurrencyRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Currency Add(Currency currency)
        {
            context.Currensies.Add(currency);
            context.SaveChanges();
            return currency;
        }

        public Currency Delete(int id)
        {
            Currency curr = context.Currensies.FirstOrDefault(m => m.Id == id);
            if (curr != null)
            {
                context.Currensies.Remove(curr);
                context.SaveChanges();
            }
            return curr;
        }

        public IEnumerable<Currency> GetAllCurrencies()
        {
            return context.Currensies;
        }

        public Currency GetCurrency(int id)
        {
            return context.Currensies.Find(id);
        }

        public Currency Update(Currency currency)
        {
            var curr = context.Currensies.Attach(currency);
            curr.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return currency;
        }
    }
}
