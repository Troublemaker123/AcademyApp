using System.Collections.Generic;
using AcademyApp.Business.ViewModel;

namespace AcademyApp.Business.Interfaces
{
    public interface IAttendanceService
    {
        void Create(AttendanceViewModel model);
    }
}
