using System.Collections.Generic;
using System.Linq;
using Domain.Dtos;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IFavoriteService
    {
        IEnumerable<ProductToListDto> GetFavoritesToListByCustomer(string customerCpf);
        IQueryable<Favorite> GetFavoritesByCustomer(string customerCpf);
        void SaveFavorite(Customer customer, Product product);
        void DeleteFavorite(int customerId, int productId);
    }
}