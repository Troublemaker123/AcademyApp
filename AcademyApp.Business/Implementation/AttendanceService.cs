using AcademyApp.Business.Interfaces;
using AcademyApp.Business.Mapper;
using AcademyApp.Business.ViewModel;
using AcademyApp.Data;
using AcademyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyApp.Business.Implementation
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IRepository<Attendance> _aRepository;
        public AttendanceService(IRepository<Attendance> aRepository)
        {
            _aRepository = aRepository;
        }
        public void Create(AttendanceViewModel model)
        {
            var domain = model.ToDomain();
            _aRepository.Create(domain);
        }

        public IEnumerable<AttendanceViewModel> FindAll()
        {
            return _aRepository.GetAll().Select(model => new AttendanceViewModel()
            {
                ID = model.ID,
            }).ToList();
        }

        public AttendanceViewModel FindById(int apId)
        {
            throw new NotImplementedException();
        }

        public void Update(AttendanceViewModel model)
        {
            var program = _aRepository.FindById(new Attendance());

            if (program == null)
                throw new Exception();
            _aRepository.Update(program);
        }
    }
}
