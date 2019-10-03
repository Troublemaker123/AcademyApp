using AcademyApp.Business.ViewModel;
using AcademyApp.Data.Model;
using AcademyApp.Model;
using AcademyApp.Business.Enums;
using AcademyApp.Business.ViewModels;
using AcademyApp.Data.Domains;

namespace AcademyApp.Business.Mapper
{
    public static class Mappers
    {
        public static AcademyProgram ToDomain(this AcademyProgramViewModel model)
        {
            return new AcademyProgram
            {
                Id = model.Id,
                CreatedOn = model.CreatedOn,
                CreatedBy = model.CreatedBy,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                IsCurrent = model.IsCurrent
            };
        }

        public static AcademyProgramViewModel ToModel(this AcademyProgram model)
        {
            return new AcademyProgramViewModel
            {
                Id = model.Id,
                CreatedBy = model.CreatedBy,
                CreatedOn = model.CreatedOn,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                IsCurrent = model.IsCurrent
            };

        }
        public static Student ToDomain(this StudentViewModel model)
        {
            return new Student
            {
                ID = model.ID,
                Name = model.Name,
                LastName = model.LastName,
                Address = model.Address,
                PlaceOfBirth = model.PlaceOfBirth,
                Country = model.Country,
                Mobile = model.Mobile,
                EmailAdress = model.EmailAdress,
                GraduationYear = model.GraduationYear,
                DateOfBirth = model.DateOfBirth,
                DateOfEnrollment = model.DateOfEnrollment,
                GenderId = model.Gender == Gender.None ? (int?)null : (int)model.Gender,
                ApId = model.AcademyProgramId
            };
        }
        public static StudentViewModel ToModel(this Student model)
        {
            return new StudentViewModel
            {
                ID = model.ID,
                Name = model.Name,
                LastName = model.LastName,
                PlaceOfBirth = model.PlaceOfBirth,
                Address = model.Address,
                Country = model.Country,
                Mobile = model.Mobile,
                EmailAdress = model.EmailAdress,
                GraduationYear = model.GraduationYear,
                DateOfBirth = model.DateOfBirth,
                DateOfEnrollment = model.DateOfEnrollment,
                Gender = !model.GenderId.HasValue ? Gender.None : (Gender)model.GenderId.Value,
                AcademyProgramId = model.ApId
            };

        }
        public static Mentor ToDomain(this MentorViewModel model)
        {
            return new Mentor
            {
                ID = model.ID,
                Name = model.Name,
                LastName = model.LastName,
                Email = model.Email,
                YearsOfService = model.YearsOfService,
                Specialty = model.Specialty,
                Telephone = model.Telephone,
                // Grades = model.Grades,
                ApId = model.AcademyProgramId,

            };
        }
        public static MentorViewModel ToModel(this Mentor model)
        {
            return new MentorViewModel
            {
                ID = model.ID,
                Name = model.Name,
                LastName = model.LastName,
                Email = model.Email,
                YearsOfService = model.YearsOfService,
                Specialty = model.Specialty,
                Telephone = model.Telephone,
                //Grades = model.Grades,
                AcademyProgramId = model.ApId,
            };

        }
        public static Program ToDomain(this ProgramViewModel model)
        {
            return new Program
            {
                ID = model.ID,
                Name = model.Name,
                Description = model.Description
            };
        }
        public static ProgramViewModel ToModel(this Program model)
        {
            return new ProgramViewModel
            {
                ID = model.ID,
                Name = model.Name,
                Description = model.Description
            };
        }
        //public static Attendance ToDomain(this AttendanceViewModel model)
        //{
        //    return new Attendance
        //    {
        //        ID = model.ID,
        //        Attended = model.Attended,
        //        Date = model.Date
        //    };
        //}
        //public static AttendanceViewModel ToModel(this Attendance model)
        //{
        //    return new AttendanceViewModel
        //    {
        //        ID = model.ID,
        //        Attended = model.Attended,
        //        Date = model.Date
        //    };
        //}
        public static Subject ToDomain(this SubjectViewModel model)
        {
            return new Subject
            {
                ID = model.ID,
                Name = model.Name,
                Description = model.Description,
                ApId = model.AcademyProgramId,

            };
        }
        public static SubjectViewModel ToModel(this Subject model)
        {
            return new SubjectViewModel
            {
                ID = model.ID,
                Name = model.Name,
                Description = model.Description,
                AcademyProgramId = model.ApId,
            };
        }
        public static Role ToDomain(this RoleViewModel model)
        {
            return new Role
            {
                ID = model.ID,

            };
        }
        public static RoleViewModel ToModel(this Role model)
        {
            return new RoleViewModel
            {
                ID = model.ID,

            };
        }
        public static Staff ToDomain(this StaffViewModel model)
        {
            return new Staff
            {
                ID = model.ID,
                Name = model.Name
            };
        }
        public static StaffViewModel ToModel(this Staff model)
        {
            return new StaffViewModel
            {
                ID = model.ID,
                Name = model.Name
            };
        }
        public static Group ToDomain(this GroupViewModel model)
        {
            return new Group
            {
                ID = model.ID,
                Title = model.Title,
                ApId = model.AcademyProgramId,

            };
        }
        public static GroupViewModel ToModel(this Group model)
        {
            return new GroupViewModel
            {
                ID = model.ID,
                Title = model.Title,
                AcademyProgramId = model.ApId,

            };
        }
        public static Grade ToDomain(this GradeViewModel model)
        {
            return new Grade
            {
                ID = model.ID,
                Name = model.Name
            };
        }
        public static GradeViewModel ToModel(this Grade model)
        {
            return new GradeViewModel
            {
                ID = model.ID,
                Name = model.Name
            };
        }
        public static GradeCategory ToDomain(this GradeCategoryViewModel model)
        {
            return new GradeCategory
            {
                ID = model.ID,
                Date = model.Date,
                Attended = model.Attended

            };
        }
        public static GradeCategoryViewModel ToModel(this GradeCategory model)
        {
            return new GradeCategoryViewModel
            {
                ID = model.ID,
                Date = model.Date,
                Attended = model.Attended
            };
        }
        public static GroupMembers ToDomain(this GroupMembersViewModel model)
        {
            return new GroupMembers
            {
                Id = model.Id,
                UserType = model.UserType,
                ApId = model.AcademyProgramId,
                UserId = model.UserId,
                GroupId = model.GroupId,

            };
        }
        public static GroupMembersViewModel ToModel(this GroupMembers model)
        {
            return new GroupMembersViewModel
            {
                Id=model.Id,
                UserType = model.UserType,
                AcademyProgramId = model.ApId,
                GroupId = model.GroupId,
                UserId = model.UserId,
            };
        }



    }
}
