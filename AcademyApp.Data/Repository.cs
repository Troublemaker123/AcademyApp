using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AcademyApp.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly Context _dbContext;

        public Repository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(T entity)
        {
            var set = _dbContext.Set<T>();
            set.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }
        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }


        public T FindById(object id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public T FindByMultipleId(object firstId, object secondId)
        {
            return _dbContext.Set<T>().Find(firstId, secondId);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges();
        }

        public void SetActivity(bool entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
