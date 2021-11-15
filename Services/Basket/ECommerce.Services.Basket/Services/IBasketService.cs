using System.Collections.Generic;
using ECommerce.Services.Basket.Dtos;
using ECommerce.Shared.Dtos;
using System.Threading.Tasks;

namespace ECommerce.Services.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string userId);
        Task<Response<List<BasketItemDto>>> GetBasketItemsByName(string itemName);
        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);
        Task<Response<bool>> Delete(string userId);
    }
}
