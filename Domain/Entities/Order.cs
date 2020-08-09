using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public virtual Customer Customer { get; set; }
        public virtual string Number { get; set; }
        public virtual decimal FinalPrice { get; set; }
        public virtual ICollection<OrderProduct> Products { get; set; }
        public virtual CreditCard Card { get; set; }
        public virtual Address Address { get; set; }
        public virtual DateTime OrderDate { get; set; }
    }
}
