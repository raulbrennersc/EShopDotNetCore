using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Customer : BaseEntity
    {
        public virtual string Cpf { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual byte[] PasswordHash { get; set; }
        public virtual byte[] PasswordSalt { get; set; }
    }
}
