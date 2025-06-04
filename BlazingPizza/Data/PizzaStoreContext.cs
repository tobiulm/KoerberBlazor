using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
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

            modelBuilder.Entity<Topping>().HasData(
              new Topping()
              {
                  Id = 1,
                  Name = "Extra cheese",
                  Price = 2.50m,
              },
               new Topping()
               {
                   Id = 2,
                   Name = "American bacon",
                   Price = 2.99m,
               },
               new Topping()
               {
                   Id = 3,
                   Name = "British bacon",
                   Price = 2.99m,
               },
               new Topping()
               {
                   Id = 4,
                   Name = "Canadian bacon",
                   Price = 2.99m,
               },
               new Topping()
               {
                   Id = 5,
                   Name = "Tea and crumpets",
                   Price = 5.00m
               },
               new Topping()
               {
                   Id = 6,
                   Name = "Fresh-baked scones",
                   Price = 4.50m,
               },
               new Topping()
               {
                   Id = 7,
                   Name = "Bell peppers",
                   Price = 1.00m,
               },
               new Topping()
               {
                   Id = 8,
                   Name = "Onions",
                   Price = 1.00m,
               },
               new Topping()
               {
                   Id = 9,
                   Name = "Mushrooms",
                   Price = 1.00m,
               },
               new Topping()
               {
                   Id = 10,
                   Name = "Pepperoni",
                   Price = 1.00m,
               },
               new Topping()
               {
                   Id = 11,
                   Name = "Duck sausage",
                   Price = 3.20m,
               },
               new Topping()
               {
                   Id = 12,
                   Name = "Venison meatballs",
                   Price = 2.50m,
               },
               new Topping()
               {
                   Id = 13,
                   Name = "Served on a silver platter",
                   Price = 250.99m,
               },
               new Topping()
               {
                   Id = 14,
                   Name = "Lobster on top",
                   Price = 64.50m,
               },
               new Topping()
               {
                   Id = 15,
                   Name = "Sturgeon caviar",
                   Price = 101.75m,
               },
               new Topping()
               {
                   Id = 16,
                   Name = "Artichoke hearts",
                   Price = 3.40m,
               },
               new Topping()
               {
                   Id = 17,
                   Name = "Fresh tomatoes",
                   Price = 1.50m,
               },
               new Topping()
               {
                   Id = 18,
                   Name = "Basil",
                   Price = 1.50m,
               },
               new Topping()
               {
                   Id = 19,
                   Name = "Steak (medium-rare)",
                   Price = 8.50m,
               },
               new Topping()
               {
                   Id = 20,
                   Name = "Blazing hot peppers",
                   Price = 4.20m,
               },
               new Topping()
               {
                   Id = 21,
                   Name = "Buffalo chicken",
                   Price = 5.00m,
               },
               new Topping()
               {
                   Id = 22,
                   Name = "Blue cheese",
                   Price = 2.50m,
               }
           );

            modelBuilder.Entity<PizzaSpecial>().HasData(
               new PizzaSpecial()
               {
                   Id = 1,
                   Name = "Basic Cheese Pizza",
                   Description = "It's cheesy and delicious. Why wouldn't you want one?",
                   BasePrice = 9.99m,
                   ImageUrl = "img/pizzas/cheese.jpg",
               },
                new PizzaSpecial()
                {
                    Id = 2,
                    Name = "The Baconatorizor",
                    Description = "It has EVERY kind of bacon",
                    BasePrice = 11.99m,
                    ImageUrl = "img/pizzas/bacon.jpg",
                },
                new PizzaSpecial()
                {
                    Id = 3,
                    Name = "Classic pepperoni",
                    Description = "It's the pizza you grew up with, but Blazing hot!",
                    BasePrice = 10.50m,
                    ImageUrl = "img/pizzas/pepperoni.jpg",
                },
                new PizzaSpecial()
                {
                    Id = 4,
                    Name = "Buffalo chicken",
                    Description = "Spicy chicken, hot sauce and bleu cheese, guaranteed to warm you up",
                    BasePrice = 12.75m,
                    ImageUrl = "img/pizzas/meaty.jpg",
                },
                new PizzaSpecial()
                {
                    Id = 5,
                    Name = "Mushroom Lovers",
                    Description = "It has mushrooms. Isn't that obvious?",
                    BasePrice = 11.00m,
                    ImageUrl = "img/pizzas/mushroom.jpg",
                },
                new PizzaSpecial()
                {
                    Id = 6,
                    Name = "The Brit",
                    Description = "When in London...",
                    BasePrice = 10.25m,
                    ImageUrl = "img/pizzas/brit.jpg",
                },
                new PizzaSpecial()
                {
                    Id = 7,
                    Name = "Veggie Delight",
                    Description = "It's like salad, but on a pizza",
                    BasePrice = 11.50m,
                    ImageUrl = "img/pizzas/salad.jpg",
                },
                new PizzaSpecial()
                {
                    Id = 8,
                    Name = "Margherita",
                    Description = "Traditional Italian pizza with tomatoes and basil",
                    BasePrice = 9.99m,
                    ImageUrl = "img/pizzas/margherita.jpg",
                }
           );

        }


        private static readonly Func<PizzaStoreContext, int, string, Task<Order>> GetOrder = 
            EF.CompileAsyncQuery((PizzaStoreContext context, int orderId, string userID) =>
            context.Orders.Where(o => o.OrderId == orderId)
                .Include(o => o.DeliveryLocation)
                        .Include(o => o.Pizzas).ThenInclude(p => p.Special)
                        .Include(o => o.Pizzas).ThenInclude(p => p.Toppings).ThenInclude(t => t.Topping)
                        .OrderByDescending(o => o.CreatedTime)
                        .SingleOrDefault())!;

        public async Task<Order> GetOrderAsync(int id, string userID)
        {
            return await GetOrder(this, id, userID);
        }

        private static readonly Func<PizzaStoreContext, string, IEnumerable<Order>> GetOrders =
            EF.CompileQuery((PizzaStoreContext context, string userId) =>
            context.Orders.Where((o) => o.UserId == userId)
                        .Include(o => o.DeliveryLocation)
                        .Include(o => o.Pizzas).ThenInclude(p => p.Special)
                        .Include(o => o.Pizzas).ThenInclude(p => p.Toppings).ThenInclude(t => t.Topping).ToList()
                        .OrderByDescending(o => o.CreatedTime));

        public async Task<List<Order>> GetOrdersAsync(string userId )
        {
            var result =  await Task.FromResult(GetOrders(this, userId).ToList());
            return result;
        }

    }
}
