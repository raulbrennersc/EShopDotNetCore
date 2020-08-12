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
        public void DeleteFavorite(string customerCpf, int productId)
        {
            var favorite = _favoriteRepository.GetAll().FirstOrDefault(f => f.Product.Id == productId && f.Customer.Cpf == customerCpf);
            if (favorite != null)
            {
                _favoriteRepository.Delete(favorite.Id);
            }
        }

        public IQueryable<Favorite> GetFavoritesByCustomer(string customerCpf)
        {
            return _favoriteRepository.GetAll().Where(f => f.Customer.Cpf == customerCpf);
        }

        public IEnumerable<ProductToListDto> GetFavoritesToListByCustomer(string customerCpf)
        {
            return GetFavoritesByCustomer(customerCpf).Select(f => new ProductToListDto(f.Product));
        }

        public void SaveFavorite(Customer customer, Product product)
        {
            var favorite = _favoriteRepository.GetAll().FirstOrDefault(f => f.Product.Id == product.Id && f.Customer.Id == customer.Id);
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