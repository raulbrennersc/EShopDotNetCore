using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Domain.Dtos
{
    public class OrderDetailDto
    {
        public string Number { get; set; }
        public decimal FinalPrice { get; set; }
        public IEnumerable<ProductToListDto> Products { get; set; }
        public CreditCardDto Card { get; set; }
        public AddressDto Address { get; set; }
        public DateTime OrderDate { get; set; }

        public OrderDetailDto(Order order)
        {
            Number = order.Number;
            FinalPrice = order.FinalPrice;
            Products = order.Products.Select(p => new ProductToListDto(p.Product));
            OrderDate = order.OrderDate;
            Card = new CreditCardDto(order.Card);
            Address = new AddressDto(order.Address);
        }
    }
}