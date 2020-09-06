using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class ApplicationContext : DbContext
    {
        public ApplicationContext():base("name=CurrencyRatesContext")
        {
            
        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Rate> Rates { get; set; }
    }
}
