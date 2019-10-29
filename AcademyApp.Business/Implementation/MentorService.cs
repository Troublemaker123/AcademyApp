using System;


using AcademyApp.Business.Mapper;
using AcademyApp.Data;
using AcademyApp.Data.Domains;
using System.Collections.Generic;
using AcademyApp.Business.ViewModel;
using AcademyApp.Business.Interfaces;
using System.Linq;

namespace AcademyApp.Business
{
   public class MentorService : IMentorService
    {
        private readonly IRepository<Mentor> _mentorRepository;

        public MentorService(IRepository<Mentor> mentorRepository)
        {
            _mentorRepository = mentorRepository;
        }

        public void Create(MentorViewModel mentor)
        {
            if (mentor == null)
                throw new Exception("student not found");
            
            var domain = mentor.ToDomain();
           _mentorRepository.Create(domain);
        }

        public IEnumerable<MentorViewModel> GetAll(int academyProgramId)
        {
            return _mentorRepository.GetAll().Where(mentor => mentor.ApId == academyProgramId)
                .Select(mentor => mentor.ToModel()).ToList();
        }
       
        public MentorViewModel FindById(int mentorId)
        {
            var mentors = _mentorRepository.FindById(mentorId);
            if (mentors == null)
                throw new Exception("mentorid not found");

            return mentors.ToModel();
        }

        public void Update(MentorViewModel mentor)
        {
            var mentors = _mentorRepository.FindByMultipleId(mentor.ID,mentor.AcademyProgramId);
            if (mentors == null)
                throw new Exception("mentor not found");

            mentors.Name = mentor.Name;
            mentors.LastName = mentor.LastName;
            mentors.Specialty = mentor.Specialty;
            mentors.Telephone = mentor.Telephone;
            mentors.YearsOfService = mentor.YearsOfService;
            mentors.Email = mentor.Email;

            _mentorRepository.Update(mentors);
        }

        public void Delete(int mentorId, int academyProgramId)
        {
            var mentors = _mentorRepository.FindByMultipleId(mentorId, academyProgramId);
            if (mentors == null)
                throw new Exception("mentor not found");

            _mentorRepository.Delete(mentors);
        }
        public IEnumerable<MentorBasicViewModel> GetAllBasicMentors(int academyProgramId)
        {

            return _mentorRepository.GetAll().Where(mentor => mentor.ApId == academyProgramId)
            .Select(mentor => mentor.ToBasicModel()).ToList();
        }
    }
}
