using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Address : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Street { get; set; }
        public virtual string City { get; set; }
        public virtual string Number { get; set; }
        public virtual string ZipCode { get; set; }
        public virtual string State { get; set; }
        public virtual string Country { get; set; }
        public virtual Customer User { get; set; }
    }
}
