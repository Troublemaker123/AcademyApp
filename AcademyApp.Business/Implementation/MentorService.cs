using System;


using AcademyApp.Business.Mapper;
using AcademyApp.Data;
using AcademyApp.Data.Model;
using System.Collections.Generic;
using AcademyApp.Business.ViewModel;
namespace AcademyApp.Business.Implementation
{
   public class MentorService : IMentorService
    {
        private readonly IRepository<MentorService> _mentor;
        public MentorService(IRepository<MentorService> mentor)
        {
            _mentor = mentor;
        }
        public void Create(MentorViewModel model)
        {
            var domain = model.ToDomain();
            _mentor.Create(domain);
        }

        public List<MentorViewModel> FindAll()
        {
            throw new NotImplementedException();
        }

        public MentorViewModel FindById(int apId)
        {
            throw new NotImplementedException();
        }

        public void Update(MentorViewModel model)
        {
            throw new NotImplementedException();
        }

        public void Update(StudentViewModel model)
        {
            throw new NotImplementedException();
        }

    }
}
