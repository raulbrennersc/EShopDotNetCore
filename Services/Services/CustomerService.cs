using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _repository;
        public CustomerService(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public Customer GetCustomerByCpf(string cpf)
        {
            return _repository.GetAll().FirstOrDefault(c => c.Cpf == cpf);
        }

        public CustomerDetailDto GetDetailedCustomerByCpf(string cpf)
        {
            var customer = _repository.GetAll().FirstOrDefault(c => c.Cpf == cpf);
            return new CustomerDetailDto(customer);
        }

        public Customer Login(string cpf, string password)
        {
            cpf = cpf.Replace(".", "").Replace("-", "");
            var customer = _repository.GetAll().FirstOrDefault(u => u.Cpf == cpf);

            if (customer == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, customer.PasswordHash, customer.PasswordSalt))
            {
                return null;
            }

            return customer;
        }

        public Customer Register(CustomerRegisterDto newCustomerDto)
        {
            var newCustomer = new Customer
            {
                FirstName = newCustomerDto.FirstName,
                LastName = newCustomerDto.LastName,
                Cpf = newCustomerDto.Cpf.Replace(".", "").Replace("-", ""),
                Email = newCustomerDto.Email,
            };

            CreatePasswordHash(newCustomerDto.Password, out var passwordHash, out var passwordSalt);

            newCustomer.PasswordHash = passwordHash;
            newCustomer.PasswordSalt = passwordSalt;

            _repository.Save(newCustomer);

            return newCustomer;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (var i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public void Update(string cpf, CustomerUpdateDto customerDto)
        {
            var customer = GetCustomerByCpf(cpf);
            if (customer == null || string.IsNullOrEmpty(customerDto.Email) || string.IsNullOrEmpty(customerDto.PhoneNumber) ||
                string.IsNullOrEmpty(customerDto.FirstName) || string.IsNullOrEmpty(customerDto.LastName) ||
                customerDto.BirthDate == DateTime.MinValue)
            {
                throw new InvalidUpdateException(ServicesConstants.ERR_GENERIC_UPDATE);
            }

            customer.Email = customerDto.Email;
            customer.PhoneNumber = customerDto.PhoneNumber;
            customer.FirstName = customerDto.FirstName;
            customer.LastName = customerDto.LastName;
            customer.BirthDate = customerDto.BirthDate;
            _repository.Update(customer);
        }
    }
}
