using AutoMapper;
using Contracts.Dto.Employee;
using Contracts.DTO.User;
using Contracts.Entities;

namespace TemplateApi
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            UserMap();
            EmployeeMap();
        }

        private void UserMap()
        {
            CreateMap<User, UserDto>();
            CreateMap<User, UserDto>().ReverseMap();
        }

        private void EmployeeMap() {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}
