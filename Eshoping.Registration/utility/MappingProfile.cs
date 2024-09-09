using AutoMapper;
using Eshoping.Registration.model;
using Eshoping.Registration.model.UserRegistartion;

namespace Eshoping.Registration.utility
{
    public class MappingProfile : Profile
    {
        public MappingProfile() { 
        CreateMap<UserRegistration,UserInfo>();
        }
    }
}
