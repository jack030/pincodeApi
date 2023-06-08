

using pincodeApi.Entities.Controllers.Dto;
using pincodeApi.Entities;
using AutoMapper;

public class UserProfile : Profile
{

    public UserProfile()
    {
        CreateMap<UserDto, User>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<User, UserDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));


        CreateMap<UpdateUserDto, User>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        CreateMap<User, UpdateUserDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));


        // CreateMa

    }
}