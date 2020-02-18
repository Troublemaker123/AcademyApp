using AcademyApp.Business.ViewModel;
using System.Collections.Generic;


namespace AcademyApp.Business.Interfaces
{
    public interface IStudentService
    {
        void Create(StudentViewModel student);
        void Delete(int studentId);
        void Update(StudentViewModel student);
        IEnumerable<StudentViewModel> GetAll(int academyProgramId);
        StudentViewModel FindById(int studentId);

    }
}
