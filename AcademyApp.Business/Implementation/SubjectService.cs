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
    public class SubjectService : ISubjectService
    {
        private readonly IRepository<Subject> _subjectRepository;
        private readonly IRepository<GroupSubjects> _subjectMentorRepository;
        private readonly IRepository<Mentor> _mentorRepository;

        public SubjectService(
            IRepository<Subject> subjectRepository,
            IRepository<GroupSubjects> subjectMentorRepository,
            IRepository<Mentor> mentorRepository)
        {
            _subjectRepository = subjectRepository;
            _subjectMentorRepository = subjectMentorRepository;
            _mentorRepository = mentorRepository;

        }

        public void Create(SubjectViewModel model)
        {
            _subjectRepository.Create(model.ToDomain());
        }

        public IEnumerable<SubjectViewModel> GetAll(int academyId)
        {
            return _subjectRepository.GetAll().Where(s => s.AcademyId == academyId).Select(
                           model => model.ToModel()
                     ).ToList();
        }

        public SubjectViewModel FindById(int subjectId)
        {
            var subject = _subjectRepository.FindById(subjectId);
            if (subject == null)
                throw new Exception("subject not found");

            return subject.ToModel();
        }

        public void Update(SubjectViewModel model)
        {
            var subject = _subjectRepository.FindById(model.ID);
            if (subject == null)
                throw new Exception();

            subject.Name = model.Name;
            subject.Description = model.Description;
            subject.AcademyId = model.AcademyId;

            _subjectRepository.Update(subject);
        }

        public void Delete(int subjectId)
        {               
            var subject = _subjectRepository.FindById(subjectId);
            if (subject == null)
                throw new Exception("subject not found");

            _subjectRepository.Delete(subject);
        }
    }
}
