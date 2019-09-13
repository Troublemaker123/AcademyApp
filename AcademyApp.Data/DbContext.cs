using Microsoft.EntityFrameworkCore;
using AcademyApp.Model;
using AcademyApp.Data.Model;

namespace AcademyApp.Data
{
    public class Context : DbContext
    {   
        public Context(DbContextOptions<Context> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcademyProgram>().ToTable("AcademyProgram");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Mentor>().ToTable("Mentor");
            modelBuilder.Entity<Subject>().ToTable("Subject");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<GradeCategory> GradeCategories { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AcademyProgram> AcademyPrograms { get; set; }
             
    }
}
