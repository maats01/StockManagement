using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Buy> Purchases { get; set; }
        public DbSet<ServiceOrder> ServiceOrders { get; set; }
        public DbSet<BuyItem> BuyItems { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>()
                .HasDiscriminator<string>("Type")
                .HasValue<Customer>(TypePerson.Customer.ToString())
                .HasValue<Supplier>(TypePerson.Supplier.ToString());
        }
    }
}
