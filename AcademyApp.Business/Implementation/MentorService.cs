using System;


using AcademyApp.Business.Mapper;
using AcademyApp.Data;
using AcademyApp.Data.Model;
using System.Collections.Generic;
using AcademyApp.Business.ViewModel;
using AcademyApp.Model;
using System.Linq;

namespace AcademyApp.Business.Implementation
{
   public class MentorService : IMentorService
    {
        private readonly IRepository<Mentor> _apRepository;

        public MentorService(IRepository<Mentor> apRepository)
        {
            _apRepository = apRepository;
        }

        public void Create(MentorViewModel model)
        {
            var domain = model.ToDomain();
           _apRepository.Create(domain);
        }

        public IEnumerable<MentorViewModel> GetAll()
        {
            return _apRepository.GetAll().Select(model => new MentorViewModel()
            {
                ID = model.ID,

            }
            ).ToList();
        }

        public MentorViewModel FindById(int apId)
        {
            
        }

        public void Update(MentorViewModel model)
        {
            var program = _apRepository.FindById(new Mentor());
            if (program == null)
                throw new Exception();

            _apRepository.Update(program);
        }

    }
}
