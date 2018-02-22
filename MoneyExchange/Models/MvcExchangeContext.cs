using System;
using Microsoft.EntityFrameworkCore;

namespace MoneyExchange.Models
{
    public class MvcExchangeContext:DbContext
    {
        public MvcExchangeContext(DbContextOptions<MvcExchangeContext> options)
            : base(options)
        {
        }

        public DbSet<MoneyExchange.Models.Currency> Exchange { get; set; }
    }
}
