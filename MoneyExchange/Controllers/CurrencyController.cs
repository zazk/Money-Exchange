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

        public  async Task<JsonResult> ExchangeMultiple()
        {
            Dictionary<string, object> response = new Dictionary<string, object>();
            Dictionary<string, object> rates = new Dictionary<string, object>();

            var currencies = await _context.Exchange.ToListAsync();
            foreach ( Currency item in currencies){
                rates.Add(item.code,item.value);
            }
            response.Add("base", "USD");
            response.Add("date", "2018-02-22"); 

            response.Add("ratesss", rates);
            return Json(response);

            //{ "base":"USD","date":"2018-02-21","rates":{ "EUR":0.81222} }
        }

    }
}
