using Repository.SpecificRepository.Interfaces;

namespace Repository.GenericRepository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangeAsync(CancellationToken cancellationToken);
        IwineryRepository WineryRepository { get; }

    }
}
