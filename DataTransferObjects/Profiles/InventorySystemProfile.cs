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
            CreateMap<ProductRequest, Product>()
                .ForMember(o=>o.SerialNumber, b=>b.MapFrom(z => z.Name));
            CreateMap<Product, ProductResponse>()
                .ForMember(o => o.Name, b=>b.MapFrom(z => z.SerialNumber))
                .ForMember(o => o.CategoryName, b => b.MapFrom(z => z.Category.Name))
                .ForMember(o => o.MarkName, b => b.MapFrom(z => z.Mark.Name))
                .ForMember(o => o.ParentName, b => b.MapFrom(z => z.Parent.SerialNumber));
        }
    }
}
