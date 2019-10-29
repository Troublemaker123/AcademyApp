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
        private readonly IRepository<SubjectMentor> _subjectMentorRepository;
        private readonly IRepository<Mentor> _mentorRepository;

        public SubjectService(
            IRepository<Subject> subjectRepository,
            IRepository<SubjectMentor> subjectMentorRepository,
            IRepository<Mentor> mentorRepository)
        {
            _subjectRepository = subjectRepository;
            _subjectMentorRepository = subjectMentorRepository;
            _mentorRepository = mentorRepository;

        }

        public void Create(SubjectViewModel subjects)
        {
            if (subjects == null)
                throw new ApplicationException("group is null");

            var domain = subjects.ToDomain();
            _subjectRepository.Create(domain);

            foreach (var mentor in subjects.MentorsList)
            {
                _subjectMentorRepository.Create(new SubjectMentor
                {
                    AcademyProgramId = domain.ApId,
                    MentorId = mentor.Id,
                    SubjectId = domain.ID,
                });

            }
        }

        public IEnumerable<SubjectViewModel> GetAll(int academyProgramId)
        {

            var subjects = _subjectRepository.GetAll().Where(s => s.ApId == academyProgramId).Select(s => s.ToModel()).ToList();

            var subMentor = _subjectMentorRepository.GetAll().Where(sm => sm.AcademyProgramId == academyProgramId);

            var concatSubs =
                from sub in subMentor
                join m in _mentorRepository.GetAll() on sub.MentorId equals m.ID

                select new
                {
                    subMentor = sub,
                    Mentor = m
                };

            foreach (var subject in subjects)
            {
                var mentors = concatSubs.Where(cs => cs.subMentor.SubjectId == subject.ID).Select(cs => cs.Mentor.ToBasicModel()).ToList();
                if (mentors.Any())
                {
                    subject.MentorsList = mentors;
                }
            }

            return subjects;
        }
    
        public SubjectViewModel FindById(int subjectId)
        {
            var subject = _subjectRepository.FindById(subjectId);
            if (subject == null)
                throw new Exception("subject not found");

            return subject.ToModel();
        }

        public void Update(SubjectViewModel subject)
        {
            var subjects = _subjectRepository.FindByMultipleId(subject.ID,subject.AcademyProgramId);
            if (subjects == null)
                throw new Exception("subject not found");

            subjects.Name = subject.Name;
            subjects.Description = subject.Description;

            _subjectRepository.Update(subjects);
        }

        public void Delete(int subjectId, int academyProgramId)
        {
                
            var subjects = _subjectRepository.FindByMultipleId(subjectId, academyProgramId);
            if (subjects == null)
                throw new Exception("subject not found");

     
            _subjectRepository.Delete(subjects);
        }
    }
}
