using System.Linq.Expressions;

namespace Repository.GenericRepository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(
                                    Expression<Func<T, bool>>? where = null,
                                    Func<IQueryable<T>, IOrderedEnumerable<T>>? orderBy = null,
                                    string includeProperties = "");

        Task<T> GetFirstOrDefault(
                                    Expression<Func<T, bool>>? where = null,
                                    string includeProperties = "");

        Task Add(T entity, CancellationToken cancellationToken);
        Task Upd(int id, T entity ,CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);

    }
}
