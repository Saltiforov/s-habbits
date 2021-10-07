using AutoMapper;
using S_Habbits.Data;
using S_Habbits.Shared.ViewModel;

namespace S_Habbits.Shared.Profiles
{
    public class ToDoTaskProfile : Profile
    {
        public ToDoTaskProfile()
        {
            CreateMap<ToDoTask, ToDoTaskViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
                .ForMember(dest => dest.CreateDateTime, opt => opt.MapFrom(src => src.CreateDateTime))
                .ForMember(dest => dest.IsChecked, opt => opt.MapFrom(src => src.IsChecked))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();
        }
    }
}