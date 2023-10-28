using Microsoft.AspNetCore.Mvc.Rendering;

namespace DataTransferObjects.Dto.ViewModels
{
    public class SelectListItemViewModel
    {
        public IEnumerable<SelectListItem> CategoryDropDownList { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> MarkDropDownList { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> ParentDropDownList { get; set; } = new List<SelectListItem>();
    }
}
