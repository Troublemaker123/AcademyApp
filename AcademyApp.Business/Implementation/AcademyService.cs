using AcademyApp.Business.Interfaces;
using AcademyApp.Business.Mapper;
using AcademyApp.Business.ViewModels;
using AcademyApp.Data;
using AcademyApp.Data.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyApp.Business.Implementation
{
    public class AcademyService : IAcademyService
    {
        private readonly IRepository<Academy> _academyRepository;

        public AcademyService(IRepository<Academy> academyRepository)
        {
            _academyRepository = academyRepository;
        }

        public void Create(AcademyViewModel academy)
        {
            if (academy == null)
                throw new ApplicationException("academy is null");

            _academyRepository.Create(academy.ToDomain());
        }

        public void Delete(int academyId)
        {
            var academy = _academyRepository.FindById(academyId);
            if(academy == null)
                throw new ApplicationException("academy is null");
            _academyRepository.Delete(academy);
        }

        public AcademyViewModel FindById(int academyId)
        {
            var academy = _academyRepository.FindById(academyId);
            if (academy == null)
                throw new ApplicationException("academy not found.");

            return academy.ToModel();
        }

        public IEnumerable<AcademyViewModel> GetAll()
        {
            return _academyRepository.GetAll().Select(model => model.ToModel()).ToList();
        }

        public void Update(AcademyViewModel model)
        {
            var academy = _academyRepository.FindById(model.ID);
            if (academy == null)
                throw new ApplicationException("academy not found.");

            academy.Name = model.Name;
            academy.Description = model.Description;

            _academyRepository.Update(academy);
        }
    }
}
