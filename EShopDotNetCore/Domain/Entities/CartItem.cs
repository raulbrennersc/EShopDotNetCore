using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class CartItem : BaseEntity
    {
        public virtual int Quantity { get; set; }
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
