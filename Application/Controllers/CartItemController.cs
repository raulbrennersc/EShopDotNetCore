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
        public CartItemController(ICartItemService cartItemService, ICustomerService customerService)
        {
            _cartItemService = cartItemService;
            _custumerService = customerService;
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
            var customerCpf = HttpContext.User.FindFirst("CustomerCpf").Value;
            var customerId = _custumerService.GetCustomerByCpf(customerCpf).Id;
            _cartItemService.AddCartItem(productId, customerId);
            return HttpResponseHelper.Create(HttpStatusCode.Created, AppConstants.MSG_GENERIC_GET_SUCCESS);
        }

        [HttpDelete("{productId}")]
        public ActionResult RemoveCartItem(int productId)
        {
            var customerCpf = HttpContext.User.FindFirst("CustomerCpf").Value;
            var customerId = _custumerService.GetCustomerByCpf(customerCpf).Id;
            _cartItemService.RemoveCartItem(productId, customerId);
            return HttpResponseHelper.Create(HttpStatusCode.OK, AppConstants.MSG_GENERIC_GET_SUCCESS);
        }
    }
}