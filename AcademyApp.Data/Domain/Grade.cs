using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyApp.Model
{
    [Table("Grade")]
    public class Grade
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }


    }
}
