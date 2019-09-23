using System;


using AcademyApp.Business.Mapper;
using AcademyApp.Data;
using AcademyApp.Data.Model;
using System.Collections.Generic;
using AcademyApp.Business.ViewModel;
using AcademyApp.Business.Interfaces;
using System.Linq;
using AcademyApp.Model;

namespace AcademyApp.Business
{
   public class MentorService : IMentorService
    {
        private readonly IRepository<Mentor> _apRepository;

        public MentorService(IRepository<Mentor> apRepository)
        {
            _apRepository = apRepository;
        }

        public void Create(MentorViewModel mentor)
        {
            
            var domain = mentor.ToDomain();
           _apRepository.Create(domain);
        }

        public IEnumerable<MentorViewModel> GetAll()
        {
            return _apRepository.GetAll().Select(mentor => mentor.ToModel()).ToList();
        }

        public MentorViewModel FindById(int mentorId)
        {
            var mentors = _apRepository.FindById(mentorId);
            if (mentors == null)
                throw new Exception("mentorid not found");

            return mentors.ToModel();
        }

        public void Update(MentorViewModel mentor)
        {
            var mentors = _apRepository.FindById(mentor.ID);
            if (mentors == null)
                throw new Exception("mentor not found");

            mentors.Name = mentor.Name;
            mentors.LastName = mentor.LastName;
            mentors.Specialty = mentor.Specialty;
            mentors.Telephone = mentor.Telephone;
            mentors.YearsOfService = mentor.YearsOfService;
            mentors.Email = mentor.Email;

            _apRepository.Update(mentors);
        }

        public void Delete(MentorViewModel mentor)
        {
            var mentors = _apRepository.FindById(mentor.ID);
            if (mentors == null)
                throw new Exception("mentor not found");

            mentors.ToModel();
            _apRepository.Delete(mentors);
        }
    }
}
