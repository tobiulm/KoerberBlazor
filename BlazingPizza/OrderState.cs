using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace BlazingPizza
{
    public class OrderState(ProtectedSessionStorage protectedSessionStorage)
    {
        public bool ShowingConfigureDialog { get; set; }

        public Pizza? ConfiguringPizza { get; set; }

        private Order _order = new();

        public Order Order
        {
            get
            {
                return _order;
            }
            private set
            {
                _order = value;
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

        internal async Task LoadStateAsync()
        {
            var result = await protectedSessionStorage.GetAsync<Order>("Order");
            if(result.Value != null)
            {
                _order = result.Value;
            }
        }

        internal async Task SaveStateAsync()
        {
            await protectedSessionStorage.SetAsync("Order", _order);
        }

        private async Task RemoveStateAsync()
        {
            await protectedSessionStorage.DeleteAsync("Order");
        }

        public async Task ResetOrder()
        {
            Order = new();
            await SaveStateAsync();
        }

        public async Task ReplaceOrder(Order newOrder)
        {
            Order = newOrder;
            await SaveStateAsync();
        }

        internal async Task RemoveConfiguredPizzaItem(Pizza pizza)
        {
            Order.Pizzas.Remove(pizza);
            if(Order.Pizzas.Count >0)
            {
                await SaveStateAsync();
            }
            else
            {
                await RemoveStateAsync();
            }
        }

    }
}
