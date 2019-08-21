using AcademyApp.Business.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Business.Interfaces
{
   public interface IStaffService
    {
        void Create(StaffViewModel model);
        void Update(StaffViewModel model);
        IEnumerable<AttendanceViewModel> GetAll();
        StaffViewModel FindById(int apId);
    }
}
