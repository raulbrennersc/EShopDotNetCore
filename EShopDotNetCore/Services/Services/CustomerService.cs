using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _repo;
        public CustomerService(IRepository<Customer> repository)
        {
            _repo = repository;
        }
        public Customer GetCustomerByCpf(string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", "");
            return _repo.GetAll().FirstOrDefault(c => c.Cpf == cpf);
        }

        public Customer Login(string cpf, string password)
        {
            throw new NotImplementedException();
        }

        public Customer RegisterCustomer(CustomerRegisterDto newCustomerDto)
        {
            throw new NotImplementedException();
        }
    }
}
