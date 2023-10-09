using Repository.GenericRepository.Interfaces;
using System.Linq.Expressions;

namespace Repository.GenericRepository.Implementations
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public Task Add(T entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? where = null, Func<IQueryable<T>, IOrderedEnumerable<T>>? orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public Task<T> GetFirstOrDefault(Expression<Func<T, bool>>? where = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public Task Upd(int id, T entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
