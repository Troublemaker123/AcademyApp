﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AcademyApp.Business.ViewModel
{
  public  class UserViewModel
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }
    }
}
