using AcademyApp.Business.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Business.Interfaces
{
    public interface IRoleService
    {
        void Create(RoleViewModel model);
        void Update(RoleViewModel model);
        IEnumerable<AttendanceViewModel> GetAll();
        RoleViewModel FindById(int apId);

    }
}
