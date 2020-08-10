using System.Collections.Generic;

namespace Domain.Dtos
{
    public class ProductDetailedDto
    {
		public decimal Price { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public List<ReviewDto> Reviews { get; set; }
        public List<ProductDetailDto> Details { get; set; }
    }
}