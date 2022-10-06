using AutoMapper;
using Growth_Website.Models;
using Growth_Website.ViewModel;

namespace Growth_Website.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductViewModel, Products>().ReverseMap();
        }
    }
}
