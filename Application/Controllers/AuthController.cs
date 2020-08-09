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
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
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

            var token = TokenHelper.GenerateCostumerToken(customer, config.GetSection("AppSettings:Token").Value);
            return HttpResponseHelper.Create(HttpStatusCode.OK, AppConstants.MSG_LOGIN_SUCCESS, token);
        }
    }
}
