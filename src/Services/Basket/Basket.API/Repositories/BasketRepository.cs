using Basket.API.Models;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache distributedCache;

        public BasketRepository(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));
        }

        public async Task DeleteBasket(string userName)
        {
           await this.distributedCache.RemoveAsync(userName);
        }

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            var result = await this.distributedCache.GetStringAsync(userName);

            if(string.IsNullOrEmpty(result))
            {
                return null;
            }

            return JsonSerializer.Deserialize<ShoppingCart>(result);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            await this.distributedCache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket));

            return await GetBasket(basket.UserName);
        }
    }
}
