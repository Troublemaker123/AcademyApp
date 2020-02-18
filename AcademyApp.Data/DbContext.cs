using Microsoft.EntityFrameworkCore;
using AcademyApp.Data.Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AcademyApp.Data
{
    public class Context : DbContext
    {   
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GroupSubjects>(entity =>
            {
                entity.HasKey(x => new { x.SubjectId, x.GroupId });
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(x => new { x.Id, x.AcademyProgramId, x.StudentId, x.MentorId, x.SubjectId, x.SubCategoryId });

                entity.HasOne(s => s.Student)
                .WithMany(r => r.Ratings)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(s => s.Subject)
                .WithMany(r => r.Ratings)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(s => s.Mentor)
                .WithMany(r => r.Ratings)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<UserActivation>(entity =>
            {
                entity.HasKey(x => new { x.UserId, x.ActivationCode });
            });

            modelBuilder.Entity<User>()
                .HasMany(u => u.Emails)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.SetNull);   // don't remove Emails from db, on delete set FK to NULL

             modelBuilder.Entity<UserActivation>()
             .HasOne(ua => ua.User)
             .WithMany(u => u.UserActivations)
             .IsRequired()
             .OnDelete(DeleteBehavior.Cascade);      // delete user activation codes on user deletion

        }

        public DbSet<GroupStudents> GroupStudents { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<GroupSubjects> GroupSubjects { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AcademyProgram> AcademyPrograms { get; set; }
        public DbSet<Academy> Academies { get; set; }
        public DbSet<GroupMentors> GroupMentors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<NonWorkingDay> NonWorkingDays { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<UserActivation> UserActivations { get; set; }
    }
}
