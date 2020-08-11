using System.Collections.Generic;
using Domain.Dtos;

namespace Domain.Interfaces
{
    public interface ICartItemService
    {
        IEnumerable<CartItemDto> GetCartItemsByCustomer(int customerId);
        void AddCartItem(int productId, int customerId);
        void RemoveCartItem(int productId, int customerId);
    }
}