using System;


using AcademyApp.Business.Mapper;
using AcademyApp.Data;
using AcademyApp.Data.Model;
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
                throw new Exception("subject not found");

            var subjects = subject.ToDomain();
            subjects.Name = "Darko";
            subjects.Description = "test";
            _subjectRepository.Create(subjects);
        }

        public IEnumerable<SubjectViewModel> GetAll()
        {
            return _subjectRepository.GetAll().Select(subject => subject.ToModel()).ToList();
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
            var subjects = _subjectRepository.FindById(subject.ID);
            if (subjects == null)
                throw new Exception("subject not found");

            subjects.Name = subject.Name;
            subjects.Description = subject.Description;    

            _subjectRepository.Update(subjects);
        }

        public void Delete(SubjectViewModel subject)
        {
            var subjects = _subjectRepository.FindById(subject.ID);
            if (subjects == null)
                throw new Exception("subject not found");

     
            _subjectRepository.Delete(subjects);
        }
    }
}
