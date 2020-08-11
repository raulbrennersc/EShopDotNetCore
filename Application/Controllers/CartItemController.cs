using System.Net;
using Application.Helpers;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Authorize]
    [Route("v1/CartItem")]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;
        private readonly ICustomerService _custumerService;
        private readonly IProductService _productService;
        private readonly IUnitOfWork _uow;
        public CartItemController(ICartItemService cartItemService, ICustomerService customerService, IProductService productService, IUnitOfWork unitOfWork)
        {
            _cartItemService = cartItemService;
            _custumerService = customerService;
            _productService = productService;
            _uow = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetCartItems()
        {
            var customerCpf = HttpContext.User.FindFirst("CustomerCpf").Value;
            var cartItems = _cartItemService.GetCartItemsByCustomer(customerCpf);
            return HttpResponseHelper.Create(HttpStatusCode.OK, AppConstants.MSG_GENERIC_GET_SUCCESS, cartItems);
        }

        [HttpPost("{productId}")]
        public ActionResult AddCartItem(int productId)
        {
            try
            {
                var customerCpf = HttpContext.User.FindFirst("CustomerCpf").Value;
                var customer = _custumerService.GetCustomerByCpf(customerCpf);
                var product = _productService.GetProductById(productId);
                _cartItemService.AddCartItem(product, customer);
                _uow.Commit();
                return HttpResponseHelper.Create(HttpStatusCode.Created, AppConstants.MSG_GENERIC_GET_SUCCESS);
            }
            catch
            {
                _uow.Rollback();
                return HttpResponseHelper.Create(HttpStatusCode.InternalServerError, AppConstants.ERR_GENERIC);
            }
        }

        [HttpDelete("{productId}")]
        public ActionResult RemoveCartItem(int productId)
        {
            try
            {
                var customerCpf = HttpContext.User.FindFirst("CustomerCpf").Value;
                var customerId = _custumerService.GetCustomerByCpf(customerCpf).Id;
                _cartItemService.RemoveCartItem(productId, customerId);
                _uow.Commit();
                return HttpResponseHelper.Create(HttpStatusCode.OK, AppConstants.MSG_GENERIC_GET_SUCCESS);
            }
            catch
            {
                _uow.Rollback();
                return HttpResponseHelper.Create(HttpStatusCode.InternalServerError, AppConstants.ERR_GENERIC);
            }
        }
    }
}