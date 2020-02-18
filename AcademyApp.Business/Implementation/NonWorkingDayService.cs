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
    public class NonWorkingDayService : INonWorkingDayService
    {
        private readonly IRepository<NonWorkingDay> _nonWorkingDayRepository;

        public NonWorkingDayService(IRepository<NonWorkingDay> nonWorkingDayRepository)
        {
            _nonWorkingDayRepository = nonWorkingDayRepository;
        }
        public void Create(NonWorkingDayViewModel model)
        {
            _nonWorkingDayRepository.Create(model.ToDomain());
        }

        public void Delete(int cId)
        {
            var day = _nonWorkingDayRepository.FindById(cId);
            if (day == null)
                throw new Exception("Event Date not found");

            _nonWorkingDayRepository.Delete(day);
        }

        public NonWorkingDayViewModel FindById(int cId)
        {
            var day = _nonWorkingDayRepository.FindById(cId);
            if (day == null)
                throw new ApplicationException("Event Date not found.");

            return day.ToModel();
        }

        public IEnumerable<NonWorkingDayViewModel> GetAll(int academyProgramId)
        {
            return _nonWorkingDayRepository.GetAll().Where(nw => nw.AcademyProgramId == academyProgramId).Select(
               model => model.ToModel()
         ).ToList();
        }

        public void Update(NonWorkingDayViewModel model)
        {
            var day = _nonWorkingDayRepository.FindById(model.Id);
            if (day == null)
                throw new Exception();

            day.AcademyProgramId = model.AcademyProgramId;
            day.EventTypeId = model.EventTypeId;
            day.EventDate = model.EventDate;

            _nonWorkingDayRepository.Update(day);
        }
    }
}
