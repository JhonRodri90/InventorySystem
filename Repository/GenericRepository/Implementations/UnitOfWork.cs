using Context.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repository.GenericRepository.Interfaces;
using Repository.SpecificRepository.Implementations;
using Repository.SpecificRepository.Interfaces;

namespace Repository.GenericRepository.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        public IwineryRepository WineryRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            WineryRepository = new WineryRepository(this.context);
        }
        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<int> SaveChangeAsync(CancellationToken cancellationToken)
        {
            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}
