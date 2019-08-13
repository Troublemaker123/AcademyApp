
namespace AcademyApp.Data
{
    public interface IRepository<T>
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void FindAll(T entity);
    }
}
