﻿using System.Collections.Generic;

namespace AcademyApp.Business.ViewModel
{
   public class SubjectViewModel
    {
        public int ID { get; set; }

        public int AcademyProgramId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public List<MentorBasicViewModel> MentorsList { get; set; }

    }
}
