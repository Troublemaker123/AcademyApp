using AcademyApp.Business.Interfaces;
using AcademyApp.Business.ViewModel;
using AcademyApp.Data;
using AcademyApp.Data.Domains;
using System;
using System.Collections.Generic;

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
            throw new NotImplementedException();
        }

        public IEnumerable<AttendanceViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public AttendanceViewModel FindById(int apId)
        {
            throw new NotImplementedException();
        }

        public void Update(AttendanceViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
