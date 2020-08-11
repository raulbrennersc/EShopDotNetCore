using System.Collections.Generic;
using System.Linq;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;

namespace Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;
        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public IEnumerable<ProductToListDto> GetFilteredProducts(ProductFilterDto filter)
        {
            var products = _repository.GetAll();
            if (filter.MinPrice != null)
            {
                products = products.Where(p => p.Price >= filter.MinPrice);
            }

            if (filter.MaxPrice != null)
            {
                products = products.Where(p => p.Price <= filter.MinPrice);
            }

            if (filter.MinRating != null)
            {
                products = products.Where(p => p.Reviews.Sum(r => r.Rating) / p.Reviews.Count() >= filter.MinRating);
            }

            if (filter.MaxRating != null)
            {
                products = products.Where(p => p.Reviews.Sum(r => r.Rating) / p.Reviews.Count() <= filter.MaxRating);
            }

            if (filter.Categories != null && filter.Categories.Count() > 0)
            {
                products = products.Where(p => p.Categories.Any(c => filter.Categories.Contains(c.Category.Id)));
            }

            if (filter.Page > 0)
            {
                products = products.Skip((filter.Page - 1) * ServicesConstants.PRODUCT_ITEMS_PAGE).Take(ServicesConstants.PRODUCT_ITEMS_PAGE);
            }

            return products.Select(p => new ProductToListDto(p)).ToList();
        }

        public ProductDetailedDto GetProductById(int id)
        {
            var product = _repository.Get(id);
            return product == null ? null : new ProductDetailedDto(product);
        }
    }
}