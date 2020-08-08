using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Review : BaseEntity
    {
        public virtual string Text { get; set; }
        public virtual int Rating { get; set; }
        public virtual Product Product { get; set; }
        public virtual Customer User { get; set; }
    }
}
