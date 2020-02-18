using AcademyApp.Business.ViewModel;
using AcademyApp.Business.Enums;
using AcademyApp.Business.ViewModels;
using AcademyApp.Data.Domains;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyApp.Business.Mapper
{
    public static class Mappers
    {
        #region Academy
        public static Academy ToDomain(this AcademyViewModel model)
        {
            return new Academy
            { 
                ID = model.ID,
                Name = model.Name,
                Description = model.Description
            };
        }

        public static AcademyViewModel ToModel(this Academy model)
        {
            return new AcademyViewModel
            {
                ID = model.ID,
                Name = model.Name,
                Description = model.Description
            };
        }
        #endregion

        #region AcademyProgram
        public static AcademyProgram ToDomain(this AcademyProgramViewModel model)
        {
            return new AcademyProgram
            {
                ID = model.ID,
                CreatedOn = model.CreatedOn,
                CreatedBy = model.CreatedBy,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                IsCurrent = model.IsCurrent,
                AcademyId = model.AcademyId
            };
        }

        public static AcademyProgramViewModel ToModel(this AcademyProgram model)
        {
            return new AcademyProgramViewModel
            {
                ID = model.ID,
                CreatedBy = model.CreatedBy,
                CreatedOn = model.CreatedOn,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                IsCurrent = model.IsCurrent,
                AcademyId = model.AcademyId,
                AcademyName = model.Academy.Name
            };

        }

        #endregion

        #region User
        public static User ToDomain(this UserViewModel model)
        {
            return new User
            {
                ID = model.ID,
                UserName = model.UserName,
                //Password = model.Password,
                IsActive = model.IsActive,
                RoleId = model.RoleId,
                Token = model.Token,
                EmailAddress = model.EmailAdress,
                IsEmailVerified = model.IsEmailVerified,
                IsPasswordChanged = model.IsPasswordChanged,
                PasswordChangedDate = model.PasswordChangedDate
            };
        }
        public static UserViewModel ToModel(this User model)
        {
            return new UserViewModel
            {
                ID = model.ID,
                UserName = model.UserName,
                //Password = model.Password,
                IsActive = model.IsActive,
                RoleId = model.RoleId,
                UserRole = model.Role.Description,
                Token = model.Token,
                EmailAdress = model.EmailAddress,
                IsEmailVerified = model.IsEmailVerified,
                IsPasswordChanged = model.IsPasswordChanged,
                PasswordChangedDate = model.PasswordChangedDate
            };
        }
        #endregion

        #region Student
        public static Student ToDomain(this StudentViewModel model)
        {
            return new Student
            {
                ID = model.ID,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                PlaceOfBirth = model.PlaceOfBirth,
                Country = model.Country,
                Mobile = model.Mobile,
                EmailAdress = model.EmailAdress,
                GraduationYear = model.GraduationYear,
                DateOfBirth = model.DateOfBirth,
                DateOfEnrollment = model.DateOfEnrollment,
                GenderId = model.GenderId,
                AcademyProgramId = model.AcademyProgramId
            };
        }
        public static StudentViewModel ToModel(this Student model)
        {
            return new StudentViewModel
            {
                ID = model.ID,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PlaceOfBirth = model.PlaceOfBirth,
                Address = model.Address,
                Country = model.Country,
                Mobile = model.Mobile,
                EmailAdress = model.EmailAdress,
                GraduationYear = model.GraduationYear,
                DateOfBirth = model.DateOfBirth,
                DateOfEnrollment = model.DateOfEnrollment,
                GenderId = !model.GenderId.HasValue ? null : model.GenderId,
                GenderName = !model.GenderId.HasValue ? "N/A" : (Enum.GetName(typeof(Gender), (int)model.GenderId)),
                AcademyProgramId = !model.AcademyProgramId.HasValue ? null : model.AcademyProgramId
               
        };

        }
        #endregion

        #region Mentor
        public static Mentor ToDomain(this MentorViewModel model)
        {
            return new Mentor
            {
                ID = model.ID,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                YearsOfService = model.YearsOfService,
                Specialty = model.Specialty,
                Telephone = model.Telephone,
                UserId = model.UserId
            };
        }
        public static MentorViewModel ToModel(this Mentor model)
        {
            return new MentorViewModel
            {
                ID = model.ID,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                YearsOfService = model.YearsOfService,
                Specialty = model.Specialty,
                Telephone = model.Telephone,
                UserId  = model.UserId
            };

        }
        public static MentorBasicViewModel ToBasicModel(this Mentor model)
        {
            return new MentorBasicViewModel
            {
                FullName = $"{ model.FirstName } { model.LastName}",
                Id = model.ID
            };

        }
        #endregion

        #region Subject
        public static Subject ToDomain(this SubjectViewModel model)
        {
            return new Subject
            {
                ID = model.ID,
                Name = model.Name,
                Description = model.Description,
                AcademyId = model.AcademyId
            };
        }
        public static SubjectViewModel ToModel(this Subject model)
        {
            return new SubjectViewModel
            {
                ID = model.ID,
                Name = model.Name,
                Description = model.Description,
                AcademyId = model.AcademyId
            };
        }

        #endregion

        #region Role
        public static Role ToDomain(this RoleViewModel model)
        {
            return new Role
            {
                ID = model.ID,
                Description = model.Description
            };
        }
        public static RoleViewModel ToModel(this Role model)
        {
            return new RoleViewModel
            {
                ID = model.ID,
                Description = model.Description
            };
        }
        #endregion

        #region Group
        public static Group ToDomain(this GroupViewModel model)
        {
            return new Group
            {
                ID = model.ID,
                Name = model.Name,
                AcademyProgramId = model.AcademyProgramId
            };
        }
        public static GroupViewModel ToModel(this Group model)
        {
            return new GroupViewModel
            {
                ID = model.ID,
                Name = model.Name,
                AcademyProgramId = model.AcademyProgramId,
                AcademyProgramName = $"{ model.AcademyProgram.Academy.Name }: {model.AcademyProgram.EndDate.ToString("yyyy")}"
            };
        }
        #endregion

        #region GroupStudents
        public static GroupStudents ToDomain(this GroupStudentsViewModel model)
        {
            return new GroupStudents
            {
                ID = model.Id,
                StudentId = model.StudentId,
                GroupId = model.GroupId
            };
        }
        public static GroupStudentsViewModel ToModel(this GroupStudents model)
        {
            return new GroupStudentsViewModel
            {
                Id=model.ID,
                GroupId = model.GroupId,
                StudentId = model.StudentId
            };
        }
        #endregion

        #region GroupMentors
        public static GroupMentors ToDomain(this GroupMentorsViewModel model)
        {
            return new GroupMentors
            {
                ID = model.Id,
                GroupId = model.GroupId,
                MentorId = model.MentorId,
                MentorTypeId = model.MentorTypeId
            };
        }
        public static GroupMentorsViewModel ToModel(this GroupMentors model)
        {
            return new GroupMentorsViewModel
            {
                Id = model.ID,
                GroupId = model.GroupId,
                MentorId = model.MentorId,
                MentorTypeId = model.MentorTypeId
            };
        }
        #endregion

        #region GroupSubjects
        public static GroupSubjects ToDomain(this GroupSubjectsViewModel model)
        {
            return new GroupSubjects
            {
                ID = model.Id,
                GroupId = model.GroupId,
                SubjectId = model.SubjectId
            };
        }
        public static GroupSubjectsViewModel ToModel(this GroupSubjects model)
        {
            return new GroupSubjectsViewModel
            {
                Id = model.ID,
                GroupId = model.GroupId,
                SubjectId = model.SubjectId
            };
        }
        #endregion

        #region Category
        public static Category ToDomain(this CategoryViewModel model)
        {
            return new Category
            {
                ID = model.ID,
                Name = model.Name
            };
        }
        public static CategoryViewModel ToModel(this Category model)
        {
            return new CategoryViewModel
            {              
                ID = model.ID,
                Name = model.Name,
                SubCategories = model.SubCategories.Select(x => x.ToModel()).ToList()
            };
        }
        #endregion

        #region SubCategory
        public static SubCategory ToDomain(this SubCategoryViewModel model)
        {
            return new SubCategory
            {
                ID = model.ID,
                Name = model.Name,
                CategoryId = model.CategoryId
            };
        }
        public static SubCategoryViewModel ToModel(this SubCategory model)
        {
            return new SubCategoryViewModel
            {
                ID = model.ID,
                Name = model.Name,
                CategoryId = model.CategoryId,
                CategoryName = model.Category.Name
            };
        }
        #endregion

        #region Email
        public static Email ToDomain(this EmailViewModel model)
        {
            return new Email
            {
                Id = model.Id,
                ToMail = model.ToMail,
                Subject = model.Subject,
                Message = model.Message,
                IsSent = model.IsSent,
                UserId = model.UserId.HasValue ? model.UserId : null,
                CreatedOn = model.CreatedOn
            };
        }
        public static EmailViewModel ToModel(this Email model)
        {
            return new EmailViewModel
            {
                Id = model.Id,
                ToMail = model.ToMail,
                Subject = model.Subject,
                Message = model.Message,
                IsSent = model.IsSent,
                UserId = model.UserId.HasValue ? model.UserId : null,
                CreatedOn = model.CreatedOn
            };
        }
        #endregion

        #region ClassRoom
        public static Classroom ToDomain(this ClassRoomViewModel model)
        {
            return new Classroom
            {
                Id = model.Id,
                Name = model.Name,
                Location = model.Location
            };
        }
        public static ClassRoomViewModel ToModel(this Classroom model)
        {
            return new ClassRoomViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Location = model.Location
            };
        }
        #endregion

        #region NonWorkingDay
        public static NonWorkingDay ToDomain(this NonWorkingDayViewModel model)
        {
            return new NonWorkingDay
            {
                Id = model.Id,
                AcademyProgramId = model.AcademyProgramId,
                EventTypeId = model.EventTypeId,
                EventDate = model.EventDate
            };
        }
        public static NonWorkingDayViewModel ToModel(this NonWorkingDay model)
        {
            return new NonWorkingDayViewModel
            {
                Id = model.Id,
                AcademyProgramId = model.AcademyProgramId,
                EventTypeId = model.EventTypeId,
                EventName = Enum.GetName(typeof(EventType), (int)model.EventTypeId),
                EventDate = model.EventDate
            };
        }
        #endregion

        #region Rating
        public static Rating ToDomain(this RatingViewModel model)
        {
            return new Rating
            {
                Id = model.Id,
                MentorId = model.MentorId,
                StudentId = model.StudentId,
                SubjectId = model.SubjectId,
                SubCategoryId = model.SubCategoryId,
                AcademyProgramId = model.AcademyProgramId,
                Grade = model.Grade,
                Comment = model.Comment
            };
        }
        public static RatingViewModel ToModel(this Rating model)
        {
            return new RatingViewModel
            {
                Id = model.Id,
                MentorId = model.MentorId,
                StudentId = model.StudentId,
                SubjectId = model.SubjectId,
                SubCategoryId = model.SubCategoryId,
                AcademyProgramId = model.AcademyProgramId,
                Grade = model.Grade,
                Comment = model.Comment
            };
        }
        #endregion



    }
}
