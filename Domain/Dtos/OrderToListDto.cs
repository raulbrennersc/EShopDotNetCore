using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Domain.Dtos
{
    public class OrderToListDto
    {
        public string Number { get; set; }
        public decimal FinalPrice { get; set; }
        public IEnumerable<ProductToListDto> Products { get; set; }
        public DateTime OrderDate { get; set; }

        public OrderToListDto(Order order)
        {
            Number = order.Number;
            FinalPrice = order.FinalPrice;
            Products = order.Products.Select(p => new ProductToListDto(p.Product));
            OrderDate = order.OrderDate;
        }
    }
}