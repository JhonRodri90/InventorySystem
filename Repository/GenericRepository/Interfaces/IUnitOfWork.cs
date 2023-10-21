using Repository.SpecificRepository.Interfaces;

namespace Repository.GenericRepository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IWineryRepository WineryRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IMarkRepository MarkRepository { get; }
        IProductRepository ProductRepository { get; }
    }
}
