using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class CustomerUpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
