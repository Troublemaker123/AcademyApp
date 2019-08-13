using System;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AcademyApp.Model;

namespace AcademyApp.Data
{
    public class Context : DbContext
    {   
        public Context(DbContextOptions<Context> options)
            : base(options)
        { }

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

    }
}
