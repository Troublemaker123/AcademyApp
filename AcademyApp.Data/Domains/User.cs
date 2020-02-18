using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyApp.Data.Domains
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100)]
        public string Password { get; set; }

        public bool IsActive { get; set; } = false;

        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        public string Token { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string EmailAddress { get; set; }
        public bool IsEmailVerified { get; set; } = false;
        public bool IsPasswordChanged { get; set; } = false;
        public DateTime? PasswordChangedDate { get; set; }

        public Mentor Mentor { get; set; }
        public Student Student { get; set; }
        public ICollection<Email> Emails { get; set; }
        public ICollection<UserActivation> UserActivations { get; set; }
    }
}
