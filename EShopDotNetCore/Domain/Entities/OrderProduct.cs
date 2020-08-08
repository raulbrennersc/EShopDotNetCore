using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class OrderProduct : BaseEntity
    {
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual decimal OrderProductPrice { get; set; }
    }
}
