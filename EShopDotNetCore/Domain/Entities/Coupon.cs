using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Coupon : BaseEntity
    {
        public virtual string Cod { get; set; }
        public virtual decimal Discount { get; set; }
        public virtual DateTime ExpiriationDate { get; set; }
    }
}
