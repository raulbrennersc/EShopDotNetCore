using System.Linq;
using Domain.Entities;

namespace Domain.Dtos
{
    public class ProductToListDto
    {
        public virtual decimal Price { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual double Rating { get; set; }

        public ProductToListDto(Product product)
        {
            Price = product.Price;
            Name = product.Name;
            Description = product.Description;
            Rating = product.Reviews.Sum(r => r.Rating) / product.Reviews.Count();
        }
    }
}