
using Context.Entities;
using Repository.GenericRepository.Implementations;
using Repository.SpecificRepository.Interfaces;
using System.Linq.Expressions;

namespace Repository.SpecificRepository.Implementations
{
    public class WineryRepository : GenericRepository<Winery>, IwineryRepository
    {
        public WineryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
