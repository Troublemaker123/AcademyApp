using AcademyApp.Business.ViewModel;
using System.Collections.Generic;

namespace AcademyApp.Business.Interfaces
{
   public interface IGradeService
    {
        void Create(GradeViewModel model);
        void Update(GradeViewModel model);
        GradeViewModel FindById(int apId);
        IEnumerable<AttendanceViewModel> GetAll();
    }
   
}
