using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyExchange.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoneyExchange.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly MvcExchangeContext _context;

        public CurrencyController( MvcExchangeContext context){
            _context = context;
        }
        // GET: /<controller>/
        public string Index()
        {
            return "At Currency Controller Index()";
        }

        public async Task<JsonResult> Exchange(){
            Dictionary<string, object> response = new Dictionary<string, object>();
            Dictionary<string, object> rates = new Dictionary<string, object>();

            var curr = await _context.Exchange.SingleOrDefaultAsync(m=>m.code == "EUR");
            response.Add("base","USD");
            response.Add("date","2018-02-22");
            rates.Add("EUR",curr.value);
            response.Add("rates",rates );
            return Json( response );

            //{ "base":"USD","date":"2018-02-21","rates":{ "EUR":0.81222} }
        }

        public JsonResult ExchangeMultiple()
        {
            Dictionary<string, object> response = new Dictionary<string, object>();
            Dictionary<string, object> rates = new Dictionary<string, object>();

            response.Add("base", "USD");
            response.Add("date", "2018-02-22");
            rates.Add("EUR", "0.5812222");
            rates.Add("AUD", "0.4812222");
            rates.Add("BGN", "0.1812222");
            rates.Add("BRL", "0.6812222");
            rates.Add("CAD", "2.812222");
            rates.Add("CHF", "4.812222");
            response.Add("rates", rates);
            return Json(response);

            //{ "base":"USD","date":"2018-02-21","rates":{ "EUR":0.81222} }
        }

    }
}
