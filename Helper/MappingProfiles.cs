using AutoMapper;
using Vidly.Dto;
using Vidly.Models;

namespace Vidly.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employees, EmployeeDto>().ReverseMap();
     






        }
    }
}
