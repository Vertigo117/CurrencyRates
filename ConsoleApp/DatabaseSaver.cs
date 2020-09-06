using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class DatabaseSaver
    {
        public void SaveCurrencies(List<Currency> currencies)
        {
            using (var db = new ApplicationContext())
            {
                var existingCurrencies = db.Currencies.ToList();

                currencies = currencies.Except(existingCurrencies).ToList();

                db.Currencies.AddRange(currencies);
                db.SaveChanges();
            }
        }

        public void SaveRates(List<Rate> rates)
        {
            using (var db = new ApplicationContext())
            {
                var existingRates = db.Rates.ToList();

                rates = rates.Except(existingRates).ToList();

                db.Rates.AddRange(rates);
                db.SaveChanges();
            }
        }
    }
}
