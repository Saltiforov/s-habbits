using AutoMapper;
using S_Habbits.Data;
using S_Habbits.Shared.ViewModel;

namespace S_Habbits.Shared.Profiles
{
    public class HabbitEventProfile : Profile
    {
        public HabbitEventProfile()
        {
            CreateMap<HabbitEvent, HabbitEventViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.DateTime))
                .ForMember(dest => dest.IsChecked, opt => opt.MapFrom(src => src.IsChecked))
                .ForMember(dest => dest.Habbit, opt => opt.MapFrom(src => src.Habbit))
                .ReverseMap();
        }
    }
}