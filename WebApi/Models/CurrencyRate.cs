using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class CurrencyRate
    {
        public string Date { get; set; }
        public string QntyName { get; set; }
        public string Value { get; set; }
    }
}