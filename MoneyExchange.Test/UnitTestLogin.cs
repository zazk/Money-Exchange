using Xunit;
using MoneyExchange.Controllers;
using MoneyExchange.Models;
using Microsoft.EntityFrameworkCore;


namespace MoneyExchange.Test
{
    public class MoneyExchangeIsLogin
    {
        private LoginController login;
        private readonly MvcExchangeContext _context;

        public MoneyExchangeIsLogin(){
            var optionsBuilder = new DbContextOptionsBuilder<MvcExchangeContext>();
            var context = new MvcExchangeContext(optionsBuilder.Options);
            _context = context;

        }

        [Fact]
        public void TestIsUserLoginWorking()
        {

            login = new LoginController(_context);
            var result = login.Index("admin");
            Assert.Same(result, "Logged");
        }
    }
}
