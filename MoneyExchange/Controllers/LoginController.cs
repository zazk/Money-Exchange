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
    public class LoginController : Controller
    {
        private readonly MvcExchangeContext _context;

        public LoginController(MvcExchangeContext context){
            _context = context;
        }
        // GET: /<controller>/
        public string Index( string user )
        {
            if(user == "admin"){
                return "Logged";
            }
            throw new NotImplementedException("Please create a test first");
        }

        public async Task<JsonResult> Verify( string login, string password){

            if (login == null || password == null){
                return Json( new { error = "User not found" } );
            }
            var user = await _context.User
                .SingleOrDefaultAsync(m => m.login == login && m.password == password);

            if( user == null){
                return Json(new { error = "User or Password was wrong" });
            }else{
                return Json(user);
            }
        }
    }
}
