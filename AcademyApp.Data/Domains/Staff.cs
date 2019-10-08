using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyApp.Data.Domains
{
    [Table("Staff")]
    public class Staff
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
