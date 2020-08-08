using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class CreditCard : BaseEntity
    {
        public virtual string Number { get; set; }
        public virtual string OwnerName { get; set; }
        public virtual int ExpirationMonth { get; set; }
        public virtual int ExpirationYear { get; set; }
        public virtual User User { get; set; }
    }
}
