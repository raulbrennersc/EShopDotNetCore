using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public virtual decimal Price { get; set; }
        public virtual string Name { get; set; }
        public virtual int Stock { get; set; }
        public virtual string Description { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<ProductDetail> Details { get; set; }
    }
}
