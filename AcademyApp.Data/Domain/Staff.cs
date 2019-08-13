﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    [Table("Staff")]
    public class Staff
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
