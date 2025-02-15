using AutoMapper;
using UsersMicroservice.Core.Entities;
using UsersMicroservice.Core.DTO;
namespace UsersMicroservice.Core.Mapper
{
    public class RegisterRequestApplicationProfile : Profile
    {
        public RegisterRequestApplicationProfile()
        {
            CreateMap<RegisterRequest, ApplicationUser>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(opt => opt.Email))
                .ForMember(dest => dest.PersonName, opt => opt.MapFrom(opt => opt.PersonName))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(opt => opt.Password))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(opt => opt.Gender.ToString()));

        }
    }
}
