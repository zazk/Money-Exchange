using Xunit;
using MoneyExchange.Controllers;


namespace MoneyExchange.Test
{
    public class MoneyExchangeIsLogin
    {
        private readonly LoginController login;

        public MoneyExchangeIsLogin(){
            login = new LoginController();

        }

        [Fact]
        public void Test1()
        {
            var result = login.Index("admin");
            Assert.Same(result, "Logged");
        }
    }
}
