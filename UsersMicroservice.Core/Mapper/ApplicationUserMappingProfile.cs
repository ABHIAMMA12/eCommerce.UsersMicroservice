using AutoMapper;
using UsersMicroservice.Core.DTO;
using UsersMicroservice.Core.Entities;

namespace UsersMicroservice.Core.Mapper
{
    public class ApplicationUserMappingProfile : Profile
    {
        public ApplicationUserMappingProfile()
        {
            CreateMap<ApplicationUser, AuthenticationResponse>()
                .ForMember(dest => dest.UserId, src => src.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Email, src => src.MapFrom(src => src.Email))
                .ForMember(dest => dest.PersonName, src => src.MapFrom(src => src.PersonName))
                .ForMember(dest => dest.Gender, src => src.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Success, src => src.Ignore())
                .ForMember(dest => dest.Token, src => src.Ignore());
        }

    }
}
