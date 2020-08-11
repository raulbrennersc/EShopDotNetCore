using System.Collections.Generic;
using Domain.Dtos;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProductService
    {
        ProductDetailedDto GetProductDetailedById(int id);
        Product GetProductById(int id);
        IEnumerable<ProductToListDto> GetFilteredProducts(ProductFilterDto filter);
    }
}