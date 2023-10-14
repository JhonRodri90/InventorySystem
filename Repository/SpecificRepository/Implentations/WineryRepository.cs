using Context.Data;
using Context.Entities;
using Repository.GenericRepository.Implentations;
using Repository.SpecificRepository.Interfaces;

namespace Repository.SpecificRepository.Implentations
{
    public class WineryRepository : GenericRepository<Winery>, IWineryRepository
    {
        public WineryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
