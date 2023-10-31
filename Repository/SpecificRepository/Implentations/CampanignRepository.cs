using Context.Data;
using Context.Entities;
using Repository.GenericRepository.Implentations;
using Repository.SpecificRepository.Interfaces;

namespace Repository.SpecificRepository.Implentations
{
    public class CampanignRepository : GenericRepository<Campanign>, ICampanignRepository
    {
        public CampanignRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
