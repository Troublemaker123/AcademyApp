using System.Collections.Generic;


namespace AcademyApp.Data
{
    public interface IRepository<T>
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        T FindById(object id);
       void SetActivity(bool entity);
    }
}
