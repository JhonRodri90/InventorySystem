using AutoMapper;
using Context.Entities;
using DataTransferObjects.Dto.In;
using DataTransferObjects.Dto.Out;

namespace DataTransferObjects.Profiles
{
    public class InventorySystemProfile : Profile
    {
        public InventorySystemProfile()
        {
            CreateMap<WineryRequest, Winery>();
            CreateMap<Winery, WineryResponse>();
        }
    }
}
