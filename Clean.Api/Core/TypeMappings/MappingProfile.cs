using AutoMapper;
using Clean.Api.ViewModels;
using Clean.Core.Domain;

namespace Clean.Api.Core.TypeMappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<User, UserViewModel>();
        }
    }
}