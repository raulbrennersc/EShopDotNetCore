﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Favorite : BaseEntity
    {
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
