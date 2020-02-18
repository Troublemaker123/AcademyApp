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
                throw new Exception("mentor not found");

           _mentorRepository.Create(mentor.ToDomain());
        }

        public IEnumerable<MentorViewModel> GetAll()
        {
            return _mentorRepository.GetAll()
                .Select(mentor => mentor.ToModel()).ToList();
        }
       
        public MentorViewModel FindById(int mentorId)
        {
            var mentors = _mentorRepository.FindById(mentorId);
            if (mentors == null)
                throw new Exception("mentorid not found");

            return mentors.ToModel();
        }

        public void Update(MentorViewModel model)
        {
            var mentor = _mentorRepository.FindById(model.ID);
            if (mentor == null)
                throw new Exception("mentor not found");

            mentor.FirstName = model.FirstName;
            mentor.LastName = model.LastName;
            mentor.Specialty = model.Specialty;
            mentor.Telephone = model.Telephone;
            mentor.YearsOfService = model.YearsOfService;
            mentor.Email = model.Email;

            _mentorRepository.Update(mentor);
        }

        public void Delete(int mentorId)
        {
            var mentors = _mentorRepository.FindById(mentorId);
            if (mentors == null)
                throw new Exception("mentor not found");

            _mentorRepository.Delete(mentors);
        }
        public IEnumerable<MentorBasicViewModel> GetAllBasicMentors(int academyProgramId)
        {

            return _mentorRepository.GetAll()//.Where(mentor => mentor.AcademyProgramId == academyProgramId)
            .Select(mentor => mentor.ToBasicModel()).ToList();
        }
    }
}
