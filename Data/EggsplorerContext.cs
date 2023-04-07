using EggSplorer.Models;
using Microsoft.EntityFrameworkCore;

namespace EggSplorer.Data
{
    public class EggsplorerContext : DbContext
    {
        public EggsplorerContext()
        {
        }

        public EggsplorerContext(DbContextOptions<EggsplorerContext> options)
            : base(options)
        {
        }

        public DbSet<Users> Users { get; set; } = null!;

        public DbSet<Products> Products { get; set; } = null!;

        public DbSet<Orders> Orders { get; set; } = null!;

        public DbSet<OrderDetails> OrderDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Eggsplorer-Part1;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Products>().ToTable("Products");
            modelBuilder.Entity<Orders>().ToTable("Orders");
            modelBuilder.Entity<OrderDetails>().ToTable("OrderDetails");
        }   
    }
}
