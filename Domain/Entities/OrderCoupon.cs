using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class OrderCoupon : BaseEntity
    {
        public virtual Order Order { get; set; }
        public virtual Coupon Coupon { get; set; }
    }
}
