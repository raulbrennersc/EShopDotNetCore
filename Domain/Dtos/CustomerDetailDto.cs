using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class CustomerDetailDto
    {
        public string Cpf { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }

        public CustomerDetailDto(Customer customer)
        {
            Cpf = customer.Cpf;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Email = customer.Email;
            PhoneNumber = customer.PhoneNumber;
            BirthDate = customer.BirthDate;
        }
    }
}
