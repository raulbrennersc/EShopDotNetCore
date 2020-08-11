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
        CustomerDetailDto GetDetailedCustomerByCpf(string cpf);
        Customer Register(CustomerRegisterDto newCustomerDto);
        Customer Login(string cpf, string password);
        Customer Update(string cpf, CustomerUpdateDto customerDto);
    }
}
