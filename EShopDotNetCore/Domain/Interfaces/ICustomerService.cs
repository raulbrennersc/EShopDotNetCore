using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces
{
    public interface ICustomerService
    {
        Customer GetCustomerByCpf(string cpf);
        Customer RegisterCustomer(CustomerRegisterDto newCustomerDto);
        Customer Login(string cpf, string password);
    }
}
