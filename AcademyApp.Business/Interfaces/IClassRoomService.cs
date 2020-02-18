using AcademyApp.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Business.Interfaces
{
    public interface IClassRoomService
    {
        void Create(ClassRoomViewModel model);
        void Update(ClassRoomViewModel model);
        IEnumerable<ClassRoomViewModel> GetAll();
        ClassRoomViewModel FindById(int cId);
        void Delete(int cId);
    }
}
