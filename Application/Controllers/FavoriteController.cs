using System.Linq;
using System.Net;
using Application.Helpers;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IFavoriteService _favoriteService;

        public FavoriteController(IFavoriteService favoriteService, ICustomerService customerService)
        {
            _customerService = customerService;
            _favoriteService = favoriteService;
        }

        [HttpGet]
        public ActionResult GetCustomerFavorites()
        {
            var customerCpf = HttpContext.User.FindFirst("CustomerCpf").Value;
            var favorites = _customerService.GetCustomerByCpf(customerCpf)
            .Favorites.Select(f => new ProductToListDto(f.Product));
            return HttpResponseHelper.Create(HttpStatusCode.OK, AppConstants.MSG_GENERIC_GET_SUCCESS, favorites);
        }

        [HttpPost("{productId}")]
        public ActionResult GetCustomerFavorites(int productId)
        {
            var customerCpf = HttpContext.User.FindFirst("CustomerCpf").Value;
            var favorites = _customerService.GetCustomerByCpf(customerCpf)
            .Favorites.Select(f => new ProductToListDto(f.Product));
            return HttpResponseHelper.Create(HttpStatusCode.OK, AppConstants.MSG_GENERIC_GET_SUCCESS, favorites);
        }
    }
}