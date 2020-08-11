using System.Collections.Generic;
using System.Linq;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;

namespace Services
{
    public class CartItemService : ICartItemService
    {
        private readonly IRepository<CartItem> _repository;

        public CartItemService(IRepository<CartItem> repository)
        {
            _repository = repository;
        }

        public void AddCartItem(int productId, int customerId)
        {
            var cartItem = _repository.GetAll().FirstOrDefault(c => c.Customer.Id == customerId && c.Product.Id == productId);
            if (cartItem != null)
            {
                cartItem.Quantity++;
                _repository.Update(cartItem);
            }
            else
            {
                cartItem = new CartItem
                {
                    Customer = new Customer { Id = customerId },
                    Product = new Product { Id = productId },
                    Quantity = 1,
                };
                _repository.Save(cartItem);
            }
        }

        public IEnumerable<CartItemDto> GetCartItemsByCustomer(string customerCpf)
        {
            customerCpf = customerCpf.Replace(".", "").Replace("-", "");
            return _repository.GetAll().Where(c => c.Customer.Cpf == customerCpf).Select(c => new CartItemDto(c));
        }

        public void RemoveCartItem(int productId, int customerId)
        {
            var cartItem = _repository.GetAll()
            .Where(c => c.Customer.Id == customerId && c.Product.Id == productId).FirstOrDefault();

            if (cartItem.Quantity == 1)
            {
                _repository.Delete(cartItem.Id);
            }
            else
            {
                cartItem.Quantity--;
                _repository.Update(cartItem);
            }
        }
    }
}