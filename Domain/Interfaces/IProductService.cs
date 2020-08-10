using System.Collections.Generic;
using Domain.Dtos;

namespace Domain.Interfaces
{
    public interface IProductService
    {
        ProductDetailedDto GetProductById(int id);
        List<ProductToListDto> GetFilteredProducts(ProductFilterDto filter);
    }
}