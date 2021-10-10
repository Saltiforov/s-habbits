using AutoMapper;
using S_Habbits.Data.Models;
using S_Habbits.Shared.ViewModel;

namespace S_Habbits.Shared.Profiles
{
    public class HabbitProfile : Profile
    {
        public HabbitProfile()
        {
            CreateMap<Habbit, HabbitViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreateDate))
                .ForMember(dest => dest.RewardPoints, opt => opt.MapFrom(src => src.RewardPoints))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();
        }
    }
}