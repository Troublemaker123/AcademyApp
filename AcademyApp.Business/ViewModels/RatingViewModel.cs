using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Business.ViewModels
{
   public class RatingViewModel
    {
        public int Id { get; set; }
        public int MentorId { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int SubCategoryId { get; set; }
        public int AcademyProgramId { get; set; }
        public int Grade { get; set; }
        public string Comment { get; set; }
    }
}
