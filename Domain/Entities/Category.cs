﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Category : BaseEntity
    {
        public virtual string Name { get; set; }
    }
}
