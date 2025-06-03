using Microsoft.EntityFrameworkCore;
namespace BlazingPizza.Data
{
    public class PizzaStoreContext(DbContextOptions<PizzaStoreContext> options): DbContext(options)
    {
        public DbSet<Pizza> Pizzas { get; set; } = null!;
        public DbSet<Topping> Toppings { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<PizzaSpecial> Specials { get; set; } = null!;
        public DbSet<Address> Address { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PizzaTopping>().HasKey(pt => new { pt.PizzaId, pt.ToppingId });
            modelBuilder.Entity<PizzaTopping>().HasOne<Pizza>().WithMany(pt => pt.Toppings);
            modelBuilder.Entity<PizzaTopping>().HasOne(pst => pst.Topping).WithMany();
            modelBuilder.Entity<Order>().OwnsOne(o => o.DeliveryLocation);
        }
    }
}
