using Context.Data;
using Repository.GenericRepository.Interfaces;
using Repository.SpecificRepository.Implentations;
using Repository.SpecificRepository.Interfaces;

namespace Repository.GenericRepository.Implentations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        public IWineryRepository WineryRepository { get; private set; }
        public ICategoryRepository CategoryRepository { get; private set; }
        public IMarkRepository MarkRepository { get; private set; }

        public IProductRepository ProductRepository { get; private set; }
        public ICampanignRepository CampanignRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            WineryRepository = new WineryRepository(this.context);
            CategoryRepository = new CategoryRepository(this.context);
            MarkRepository = new MarkRepository(this.context);
            ProductRepository = new ProductRepository(this.context);
            CampanignRepository = new CampanignRepository(this.context);

        }
        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}
