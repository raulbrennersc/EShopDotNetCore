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
        private readonly IUnitOfWork _uow;
        private readonly ICustomerService _customerService;
        private readonly IFavoriteService _favoriteService;
        private readonly IProductService _producrService;

        public FavoriteController(IUnitOfWork unitOfWork, IFavoriteService favoriteService, ICustomerService customerService, IProductService producrService)
        {
            _customerService = customerService;
            _favoriteService = favoriteService;
            _producrService = producrService;
            _uow = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetCustomerFavorites()
        {
            var customerCpf = HttpContext.User.FindFirst("CustomerCpf").Value;
            var favorites = _favoriteService.GetFavoritesToListByCustomer(customerCpf);
            return HttpResponseHelper.Create(HttpStatusCode.OK, AppConstants.MSG_GENERIC_GET_SUCCESS, favorites);
        }

        [HttpPost("{productId}")]
        public ActionResult AddCustomerFavorite(int productId)
        {
            var customerCpf = HttpContext.User.FindFirst("CustomerCpf").Value;
            var customer = _customerService.GetCustomerByCpf(customerCpf);
            var product = _producrService.GetProductById(productId);
            try
            {
                _favoriteService.SaveFavorite(customer, product);
                _uow.Commit();
                return HttpResponseHelper.Create(HttpStatusCode.OK, AppConstants.MSG_GENERIC_SUCCESS);
            }
            catch
            {
                _uow.Rollback();
                return HttpResponseHelper.Create(HttpStatusCode.InternalServerError, AppConstants.ERR_GENERIC);
            }
        }

        [HttpDelete("{productId}")]
        public ActionResult DeleteCustomerFavorite(int productId)
        {
            var customerCpf = HttpContext.User.FindFirst("CustomerCpf").Value;
            try
            {
                _favoriteService.DeleteFavorite(customerCpf, productId);
                _uow.Commit();
                return HttpResponseHelper.Create(HttpStatusCode.OK, AppConstants.MSG_GENERIC_SUCCESS);
            }
            catch
            {
                _uow.Rollback();
                return HttpResponseHelper.Create(HttpStatusCode.InternalServerError, AppConstants.ERR_GENERIC);
            }
        }
    }
}