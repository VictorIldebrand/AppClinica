using AutoMapper;
using Contracts.DTO.User;
using Contracts.Entities;

namespace TemplateApi
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            UserMap();
        }



        private void UserMap()
        {
            CreateMap<User, UserDto>();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
