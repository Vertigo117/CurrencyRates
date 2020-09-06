using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Parser
    {
        public async Task<string> ParseUrlAsync(string url)
        {
            var httpClient = new HttpClient();
            var txt = await httpClient.GetStringAsync(url);

            return txt;
        }

        public List<Currency> GetCurrencies(string text)
        {
            var lines = text.Split('\r', '\n').ToList();

            var currencies = lines[0].Split('|').Skip(1).Select(item =>
            {
                var lineArray = item.Split(' ');

                var currency = new Currency {Name = lineArray[1], Quantity = lineArray[0] };

                return currency;
            }).ToList();

            return currencies;
        }

        public List<Rate> GetRates(string text, List<Currency> currencies)
        {
            var lines = text.Split('\r', '\n').Skip(1).ToList();

            var rates = new List<Rate>();
            var counter = 0;

            foreach (var values in lines.Select(line => line.Split('|')))
            {
                counter += 1;

                try
                {
                    rates.AddRange(currencies.Select((currency, i) => new Rate {
                        Date = values[0], 
                        Value = values.Skip(1).ToList()[i], 
                        Currency = currency
                    }));
                }
                catch (Exception)
                {
                    var output = $"Строка {++counter} имела неверный формат.";

                    Console.WriteLine(output);
                }
            }

            //rates = rates.GroupBy(rate => rate.Date).Select(group => group.First()).ToList();

            return rates;
        }
    }

}