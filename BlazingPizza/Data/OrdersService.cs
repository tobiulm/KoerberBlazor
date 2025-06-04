using Microsoft.EntityFrameworkCore;
namespace BlazingPizza.Data
{
    public class OrdersService(PizzaStoreContext db)
    {
        public async Task<IEnumerable<OrderWithStatus>> GetOrders()
        {
            var orders = await db.GetOrdersAsync("");
            return orders.Select(OrderWithStatus.FromOrder).ToList();
        }

        public async Task<OrderWithStatus> GetOrder(int orderId)
        {
            var order = await db.GetOrderAsync(orderId, "");
            return OrderWithStatus.FromOrder(order);
        }

        public async Task<int> PlaceOrder(Order order)
        {
            var userId = "";
            order.UserId = userId;
            order.CreatedTime = DateTime.Now;

            order.DeliveryAddress = new Address()
            {
                City = "DemoOrt",
                Name = "Max Mustermann",
                PostalCode = "12345",
                Street = "Hauptstraße 1"
            };
            order.DeliveryLocation = new LatLong(52.473194004010715, 13.4030020867198);

            foreach(var pizza in order.Pizzas)
            {
                pizza.SpecialId = pizza.Special!.Id;
                pizza.Special = null;
                foreach(var topping in pizza.Toppings)
                {
                    topping.ToppingId = topping.Topping!.Id;
                    topping.Topping = null;
                }
            }

            db.Orders.Attach(order);
            await db.SaveChangesAsync();
            return order.OrderId;

        }
    }
}
