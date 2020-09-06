using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public List<Rate> Rates { get; set; }
    }

    public class Rate
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Value { get; set; }
        public Currency Currency { get; set; }
    }

}
