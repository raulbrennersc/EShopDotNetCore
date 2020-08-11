using Domain.Entities;

namespace Domain.Dtos
{
    public class CartItemDto
    {
        public int Quantity { get; set; }
        public ProductToListDto Product { get; set; }

        public CartItemDto(CartItem item)
        {
            Quantity = item.Quantity;
            Product = new ProductToListDto(item.Product);
        }
    }
}