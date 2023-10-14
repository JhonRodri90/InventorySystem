using Context.Data;
using Context.Entities;
using Repository.GenericRepository.Implentations;
using Repository.SpecificRepository.Interfaces;

namespace Repository.SpecificRepository.Implentations
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
