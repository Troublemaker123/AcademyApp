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

        public SubjectService(IRepository<Subject> subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        public void Create(SubjectViewModel subject)
        {
            if (subject == null)
                throw new Exception("student not found");

            var subjects = subject.ToDomain();
              _subjectRepository.Create(subjects);
        }

        public IEnumerable<SubjectViewModel> GetAll(int academyProgramId)
        {
            return _subjectRepository.GetAll().Where(subject => subject.ApId == academyProgramId)
                .Select(subject => subject.ToModel()).ToList();
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
