using System.Collections.Generic;
using System.Linq;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;

namespace Services.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IRepository<Favorite> _favoriteRepository;
        public FavoriteService(IRepository<Favorite> favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }
        public void DeleteFavorite(int customerId, int productId)
        {
            var favorite = _favoriteRepository.GetAll().FirstOrDefault(f => f.Product.Id == productId && f.Customer.Id == customerId);
            if (favorite != null)
            {
                _favoriteRepository.Delete(favorite.Id);
            }
        }

        public IQueryable<Favorite> GetFavoritesByCustomer(string customerCpf)
        {
            customerCpf = customerCpf.Replace(".", "").Replace("-", "");
            return _favoriteRepository.GetAll().Where(f => f.Customer.Cpf == customerCpf);
        }

        public IEnumerable<ProductToListDto> GetFavoritesToListByCustomer(string customerCpf)
        {
            return GetFavoritesByCustomer(customerCpf).Select(f => new ProductToListDto(f.Product));
        }

        public void SaveFavorite(Customer customer, Product product)
        {
            var favorite = _favoriteRepository.GetAll().FirstOrDefault(f => f.Product.Id == productId && f.Customer.Id == customerId);
            if (favorite == null)
            {
                favorite = new Favorite
                {
                    Customer = customer,
                    Product = product,
                };
                _favoriteRepository.Save(favorite);
            }
        }
    }
}