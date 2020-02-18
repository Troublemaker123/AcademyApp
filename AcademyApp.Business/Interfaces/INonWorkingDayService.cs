using AcademyApp.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Business.Interfaces
{
   public interface INonWorkingDayService
    {
        void Create(NonWorkingDayViewModel model);
        void Update(NonWorkingDayViewModel model);
        IEnumerable<NonWorkingDayViewModel> GetAll(int academyProgramId);
        NonWorkingDayViewModel FindById(int cId);
        void Delete(int cId);
    }
}
