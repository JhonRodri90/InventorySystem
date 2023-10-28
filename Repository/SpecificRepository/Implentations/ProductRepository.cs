using Context.Data;
using Context.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.GenericRepository.Implentations;
using Repository.SpecificRepository.Interfaces;

namespace Repository.SpecificRepository.Implentations
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext context;
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<SelectListItem> GetAllDropDownList(string obj)
        {
            if(obj == "Category")
            {
                return context.Categories.Where(c => c.State).Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value= c.Id.ToString()
                });
            }
            if (obj == "Mark")
            {
                return context.Marks.Where(c => c.State).Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                });
            }
            if (obj == "Product")
            {
                return context.Products.Where(c => c.State).Select(c => new SelectListItem
                {
                    Text = c.Description,
                    Value = c.Id.ToString()
                });
            }
            return default;
        }
    }
}
