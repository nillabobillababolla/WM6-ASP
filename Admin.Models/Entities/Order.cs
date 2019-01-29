﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Admin.Models.Abstracts;
using Admin.Models.Enums;

namespace Admin.Models.Entities
{
    [Table("Orders")]
    public class Order:BaseEntity<long>
    {
        public OrderTypes OrderType { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; } = new HashSet<Invoice>();
    }
}
