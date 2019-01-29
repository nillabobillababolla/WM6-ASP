﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.Models.Abstracts
{
    public abstract class BaseEntity<T>
    {
        [Key]
        [Column(Order = 1)]
        public T Id { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedTime { get; set; }

    }
}
