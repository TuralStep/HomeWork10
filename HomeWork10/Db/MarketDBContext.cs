using HomeWork10.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeWork10.Db
{
    public class MarketDBContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
