using System.Collections.Generic;


namespace AcademyApp.Data
{
    public interface IRepository<T>
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        T FindById( object id);
        T FindByMultipleId(object firstId, object secondId);
        T FindByThreeId(object firstId, object secondId, object thirdId);
        void SetActivity(bool entity);
    }
}
