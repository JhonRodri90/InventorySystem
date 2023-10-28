using DataTransferObjects.Dto.ViewModels;

namespace DataTransferObjets.Dto.Out
{
    public class ProductResponse: SelectListItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public double Cost { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool State { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int MarkId { get; set; }
        public string MarkName { get; set; } = string.Empty;
        public int? ParentId { get; set; }
        public string ParentName { get; set; } = string.Empty;
    }
}
