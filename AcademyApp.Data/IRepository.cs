
using System.Collections.Generic;
using AcademyApp.Data.Model;

namespace AcademyApp.Data
{
    public interface IRepository<T>
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        T FindByCondition(object id);
      //  object FindById(AcademyProgram academyProgram);
    }
}
