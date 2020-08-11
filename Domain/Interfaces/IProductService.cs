using System.Collections.Generic;
using Domain.Dtos;

namespace Domain.Interfaces
{
    public interface IProductService
    {
        ProductDetailedDto GetProductById(int id);
        IEnumerable<ProductToListDto> GetFilteredProducts(ProductFilterDto filter);
    }
}