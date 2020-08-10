using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Domain.Dtos
{
    public class ProductDetailedDto
    {
		public decimal Price { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public IEnumerable<ReviewDto> Reviews { get; set; }
        public IEnumerable<ProductDetailDto> Details { get; set; }

        public ProductDetailedDto(Product product)
        {
            Price = product.Price;
            Name = product.Name;
            Stock = product.Stock;
            Description = product.Description;
            Reviews = product.Reviews.Select(r => new ReviewDto(r));
            Details = product.Details.Select(d => new ProductDetailDto(d));
        }
    }
}