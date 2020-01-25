using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OA.Repo.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> Add(T entity);

        void Insert(T entity);

        void Insert(IEnumerable<T> entities);

        void Update(T entity);

        void Update(IEnumerable<T> entities);

        void Delete(T entity);

        void Delete(IEnumerable<T> entities);

        T GetById(object id);

        IQueryable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync();
    }
}
