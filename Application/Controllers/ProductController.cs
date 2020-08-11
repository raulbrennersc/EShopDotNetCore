using System.Net;
using Application.Helpers;
using Domain.Dtos;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public ActionResult GetFilteredProducts(ProductFilterDto filter)
        {
            var products = _productService.GetFilteredProducts(filter);
            return HttpResponseHelper.Create(HttpStatusCode.OK, AppConstants.MSG_GENERIC_GET_SUCCESS, products);
        }

        [HttpGet("{idProduct}")]
        public ActionResult GetDetailedProduct(int productId)
        {
            var product = _productService.GetProductById(productId);
            return HttpResponseHelper.Create(HttpStatusCode.OK, AppConstants.MSG_GENERIC_GET_SUCCESS, product);
        }
    }
}