using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class AuthDto
    {
        public string Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
