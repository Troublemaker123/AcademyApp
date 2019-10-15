﻿using Microsoft.EntityFrameworkCore;
using AcademyApp.Data.Domains;

namespace AcademyApp.Data
{
    public class Context : DbContext
    {   
        public Context(DbContextOptions<Context> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(x => new { x.ID, x.ApId });
            });

            modelBuilder.Entity<AcademyProgram>().ToTable("AcademyProgram");

            modelBuilder.Entity<Mentor>(entity =>
            {
                entity.HasKey(x => new { x.ID, x.ApId });
            });
            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(x => new { x.ID, x.ApId });
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(x => new { x.ID, x.ApId});
            });

            modelBuilder.Entity<GroupMembers>(entity =>
            {
                entity.HasKey(x => new { x.Id, x.ApId, x.UserId, x.GroupId});
            });
            modelBuilder.Entity<MentorSubject>(entity =>
            {
                entity.HasKey(x => new { x.Id, x.ApId, x.MentorId, x.SubjectId });
            });

        }
        

        public DbSet<GroupMembers> GroupMembers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AcademyProgram> AcademyPrograms { get; set; }
        public DbSet<MentorSubject> MentorSubjects { get; set; }
             
    }
}
