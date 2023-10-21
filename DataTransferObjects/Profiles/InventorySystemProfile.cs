using AutoMapper;
using Context.Entities;
using DataTransferObjets.Dto.In;
using DataTransferObjets.Dto.Out;

namespace DataTransferObjets.Profiles
{
    public class InventorySystemProfile : Profile
    {
        public InventorySystemProfile()
        {
            CreateMap<WineryRequest, Winery>();
            CreateMap<Winery, WineryResponse>();
            CreateMap<CategoryRequest, Category>();
            CreateMap<Category, CategoryResponse>();
            CreateMap<MarkRequest, Mark>();
            CreateMap<Mark, MarkResponse>();
        }
    }
}
