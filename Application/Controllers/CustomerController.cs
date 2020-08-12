using Application.Helpers;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Domain.Dtos;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [ApiController]
    [Authorize]
    [Route("v1/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly ICustomerService _customerService;
        public CustomerController(IUnitOfWork unitOfWork, ICustomerService customerService)
        {
            _uow = unitOfWork;
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult GetLoggedCustomer()
        {
            var customerCpf = HttpContext.User.FindFirst("CustomerCpf").Value;
            var customer = _customerService.GetDetailedCustomerByCpf(customerCpf);
            return HttpResponseHelper.Create(HttpStatusCode.OK, AppConstants.MSG_GENERIC_GET_SUCCESS, customer);
        }

        [HttpPut]
        public ActionResult UpdateLoggedCustomer(CustomerUpdateDto customerDto)
        {
            try
            {
                var customerCpf = HttpContext.User.FindFirst("CustomerCpf").Value;
                var customer = _customerService.Update(customerCpf, customerDto);
                _uow.Commit();
                return HttpResponseHelper.Create(HttpStatusCode.OK, AppConstants.MSG_GENERIC_UPDATE_SUCCESS, new CustomerDetailDto(customer));
            }
            catch (InvalidUpdateException ex)
            {
                _uow.Rollback();
                return HttpResponseHelper.Create(HttpStatusCode.BadRequest, ex.Message);
            }
            catch
            {
                _uow.Rollback();
                return HttpResponseHelper.Create(HttpStatusCode.InternalServerError, AppConstants.ERR_GENERIC);
            }
        }
    }
}
