using Context.Data;
using Context.Entities;
using Repository.GenericRepository.Implentations;
using Repository.SpecificRepository.Interfaces;

namespace Repository.SpecificRepository.Implentations
{
    public class MarkRepository : GenericRepository<Mark>, IMarkRepository
    {
        public MarkRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
