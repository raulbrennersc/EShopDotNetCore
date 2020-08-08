using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class CategoryProduct : BaseEntity
    {
        public virtual Product Product { get; set; }
        public virtual Category Category { get; set; }
    }
}
