using AcademyApp.Business.ViewModel;
using AcademyApp.Data.Model;
using AcademyApp.Model;


namespace AcademyApp.Business.Mapper
{
    public static class Mapper
    {
        public static AcademyProgram ToDomain(this AcademyProgramViewModel model)
        {
            return new AcademyProgram
            {
                ID = model.ID,
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
                ID = model.ID,
                CreatedBy= model.CreatedBy,
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
                PlaceOfBirth = model.PlaceOfBirth,
                Country = model.Country,
                Mobile = model.Mobile,
                EmailAdress = model.EmailAdress,
                GraduationYear = model.GraduationYear,
                DateOfBirth = model.DateOfBirth,
                DateOfEnrollment = model.DateOfEnrollment,
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
                Country = model.Country,
                Mobile = model.Mobile,
                EmailAdress = model.EmailAdress,
                GraduationYear = model.GraduationYear,
                DateOfBirth = model.DateOfBirth,
                DateOfEnrollment = model.DateOfEnrollment,
               
            };

        }
        public static Mentor ToDomain(this MentorViewModel model)
        {
            return new Mentor
            {
                ID = model.ID,
                Name = model.Name,
                LastName = model.LastName,
                Email = model.LastName,
                YearsOfService = model.YearsOfService,
                Specialty = model.Specialty,
                Telephone = model.Telephone,
                Grades = model.Grades,
                
            };
        }
        public static MentorViewModel ToModel(this Mentor model)
        {
            return new MentorViewModel
            {
                ID = model.ID,
                Name = model.Name,
                LastName = model.LastName,
                Email = model.LastName,
                YearsOfService = model.YearsOfService,
                Specialty = model.Specialty,
                Telephone = model.Telephone,
                Grades = model.Grades,

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
    }
}
