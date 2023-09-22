using AutoMapper;
using Test22_9.Models;

namespace Test22_9
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, DepartmentViewModel>();
            CreateMap<DepartmentViewModel, Department>();
            
        }
    }
}
