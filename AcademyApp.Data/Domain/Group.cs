﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    [Table("Group")]
    public class Group
    {
        [Key]
        public int GroupID { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Mentor> Mentors { get; set; }
        public ICollection<Staff> Staffs { get; set; }
    }
}
