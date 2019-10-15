using AcademyApp.Business.Interfaces;
using AcademyApp.Business.ViewModels;
using AcademyApp.Data;
using AcademyApp.Data.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Business.Implementation
{
   public class MentorSubjectService : IMentorSubjectService
    {
        private readonly IRepository<MentorSubject> _mentorSubjectRepository;
        private readonly IRepository<Mentor> _mentorRepository;
        private readonly IRepository<Subject> _subjectRepository;

        public MentorSubjectService(
            IRepository<MentorSubject> mentorSubjectRepository,
            IRepository<Mentor> mentorRepository,
            IRepository<Subject> subjectRepository)
        {
            _mentorSubjectRepository = mentorSubjectRepository;
            _mentorRepository = mentorRepository;
            _subjectRepository = subjectRepository;
        }

        public void Create(List<MentorSubjectsViewModel> models)
        {
            throw new NotImplementedException();
        }

        public void Delete(int mentorSubjectId, int academyProgramId)
        {
            throw new NotImplementedException();
        }

        public MentorSubjectsViewModel FindById(int apId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MentorSubjectsViewModel> GetAll(int mentorSubjectId, int academyProgramId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MentorSubjectsViewModel> GetMentorsAndSubjects(int mentorSubjectId, int academyProgramId)
        {
            throw new NotImplementedException();
        }
    }
}
