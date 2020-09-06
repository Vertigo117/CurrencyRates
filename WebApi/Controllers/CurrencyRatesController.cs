using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using Newtonsoft.Json;

namespace WebApi.Controllers
{
    public class CurrencyRatesController : ApiController
    {
        [HttpGet]
        public CurrencyRate GetCurrencyRate(string date, string currencyName)
        {
            using (var db = new WebApiContext())
            {
                var rates = db.Rates.Where(rate => rate.Date == date && rate.Currency.Name == currencyName).Include(rate => rate.Currency).ToList();

                var result = rates.Select(rate => new CurrencyRate
                {
                    Date = rate.Date,
                    QntyName = $"{rate.Currency.Quantity} {rate.Currency.Name}",
                    Value = rate.Value
                }).FirstOrDefault();

                return result;
            }
        }

        [HttpGet]
        public List<string> GetDates()
        {
            using (var db = new WebApiContext())
            {
                var dates = db.Rates.Select(rate => rate.Date).Distinct().ToList();

                return dates;
            }
        }

        [HttpGet]
        public List<string> GetCurrencies()
        {
            using (var db = new WebApiContext())
            {
                var currencies = db.Currencies.Select(currency => currency.Quantity + " " + currency.Name).Distinct()
                    .ToList();

                return currencies;
            }
        }
    }
}
