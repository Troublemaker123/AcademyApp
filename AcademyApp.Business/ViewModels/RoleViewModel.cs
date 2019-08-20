using AcademyApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AcademyApp.Business.ViewModel
{
   public class RoleViewModel
    {

        public int ID { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
