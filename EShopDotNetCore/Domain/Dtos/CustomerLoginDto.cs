using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class CustomerLoginDto
    {
        public string Cpf { get; set; }
        public string Password { get; set; }
    }
}
