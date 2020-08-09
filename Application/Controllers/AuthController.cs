using Application.Helpers;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly ICustomerService _customerService;
        public AuthController(IUnitOfWork unitOfWork, ICustomerService customerService)
        {
            _uow = unitOfWork;
            _customerService = customerService;
        }

        [HttpPost("register")]
        public ActionResult Register(CustomerRegisterDto newCustomerDto)
        {
            if (_customerService.GetCustomerByCpf(newCustomerDto.Cpf) != null)
            {
                return HttpResponseHelper.Create(HttpStatusCode.BadRequest, AppConstants.ERR_CPF_IN_USE);
            }

            try
            {
                _customerService.Register(newCustomerDto);
                _uow.Commit();
                return HttpResponseHelper.Create(HttpStatusCode.Created, AppConstants.MSG_REGISTER_SUCCESS);
            }
            catch
            {
                _uow.Rollback();
                return HttpResponseHelper.Create(HttpStatusCode.InternalServerError, AppConstants.ERR_GENERIC);
            }
        }

        [HttpPost("login")]
        public ActionResult Login(CustomerLoginDto customerLoginDto, [FromServices] IConfiguration config)
        {
            var customer = _customerService.Login(customerLoginDto.Cpf, customerLoginDto.Password);

            if (customer == null)
            {
                return HttpResponseHelper.Create(HttpStatusCode.Unauthorized, AppConstants.ERR_CPF_PASSWORD_INCORRECT);
            }

            var token = TokenHelper.GenerateCustumerToken(customer, config.GetSection("AppSettings:Token").Value);
            return HttpResponseHelper.Create(HttpStatusCode.OK, AppConstants.MSG_LOGIN_SUCCESS, token);
        }
    }
}
