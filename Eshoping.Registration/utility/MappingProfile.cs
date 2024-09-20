using AutoMapper;
using Eshoping.Registration.model;
using Eshoping.Registration.model.UserRegistartion;

namespace Eshoping.Registration.utility
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistration, UserInfo>();
            CreateMap<TemporaryAddress_model, TemporaryAddress>()
                .ForMember(dest => dest.HNo, opt => opt.MapFrom(src => src.HNo))
                .ForMember(dest => dest.District_Id, opt => opt.MapFrom(src => src.District_Id))
                .ForMember(dest => dest.City_Id, opt => opt.MapFrom(src => src.Cityvalue_id));
        }
    }
}
