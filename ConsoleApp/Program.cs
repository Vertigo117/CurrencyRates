using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        private const string Url = "https://www.cnb.cz/en/financial_markets/foreign_exchange_market/exchange_rate_fixing/year.txt?year=2015";

        static async Task Main(string[] args)
        {
            var parser = new Parser();
            var txt = await parser.ParseUrlAsync(Url);
            var currencies = parser.GetCurrencies(txt);
            var rates = parser.GetRates(txt, currencies);

            var dbSaver = new DatabaseSaver();

            try
            {
                dbSaver.SaveCurrencies(currencies);
                dbSaver.SaveRates(rates);

                var output = "Курсы успешно обновлены...";
                Console.WriteLine(output);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            Console.ReadKey();
        }
    }
}