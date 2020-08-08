using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ProductDetail : BaseEntity
    {
        public virtual Product Product { get; set; }
        public virtual string Label { get; set; }
        public virtual string Value { get; set; }
    }
}
