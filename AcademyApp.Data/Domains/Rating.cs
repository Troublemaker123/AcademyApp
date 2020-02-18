using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AcademyApp.Data.Domains
{
    public class Rating
    {
        public int Id { get; set; }
        public int MentorId { get; set; }
        [ForeignKey("MentorId")]
        public Mentor Mentor { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
        public int SubCategoryId { get; set; }
        [ForeignKey("SubCategoryId")]
        public SubCategory SubCategory { get; set; }
        public int AcademyProgramId { get; set; }
        [ForeignKey("AcademyProgramId")]
        public AcademyProgram AcademyProgram { get; set; }
        public int Grade { get; set; }
        public string Comment { get; set; }
    }
}
