using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class WebApiContext : DbContext
    {
        public WebApiContext() : base("CurrencyRatesContext")
        {
            Database.SetInitializer<WebApiContext>(null);
        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Rate> Rates { get; set; }
    }
}