using EggSplorer.Models;
using Microsoft.EntityFrameworkCore;

namespace EggSplorer.Data
{
    public class EggsplorerContext : DbContext
    {
        public DbSet<Customers> Customers { get; set; } = null!;

        public DbSet<Products> Products { get; set; } = null!;

        public DbSet<Orders> Orders { get; set; } = null!;

        public DbSet<OrderDetails> OrderDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Eggsplorer-Part1;Integrated Security=True;");
        }
    }
}
