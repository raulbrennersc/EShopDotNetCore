using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class CustomerRegisterDto
    {
        public string Cpf { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}
