using AutoMapper;
using EmployeeDirectory.Models;

namespace EmployeeDirectory.Mapper
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeRequest, Employee>();
        }
    }
}
