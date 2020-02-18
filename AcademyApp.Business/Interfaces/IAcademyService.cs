using AcademyApp.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Business.Interfaces
{
    public interface IAcademyService
    {
        void Create(AcademyViewModel academy);
        void Delete(int academyId);
        void Update(AcademyViewModel academy);
        IEnumerable<AcademyViewModel> GetAll();
        AcademyViewModel FindById(int academyId);
    }
}
