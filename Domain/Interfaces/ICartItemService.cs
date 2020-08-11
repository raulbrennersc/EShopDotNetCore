using System.Collections.Generic;
using Domain.Dtos;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICartItemService
    {
        IEnumerable<CartItemDto> GetCartItemsByCustomer(string customerCpf);
        void AddCartItem(Product product, Customer customer);
        void RemoveCartItem(int productId, int customerId);
    }
}