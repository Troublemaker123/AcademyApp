using System.Collections.Generic;
using AcademyApp.Business.ViewModel;

namespace AcademyApp.Business.Interfaces
{
    public interface IAttendanceService
    {
        void Create(AttendanceViewModel model);
        void Update(AttendanceViewModel model);
        List<AttendanceViewModel>FindAll();
        AttendanceViewModel FindById(int apId);
    }
}
