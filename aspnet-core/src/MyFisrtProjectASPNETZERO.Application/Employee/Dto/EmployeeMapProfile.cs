using AutoMapper;

namespace MyFisrtProjectASPNETZERO.Employee.Dto
{
    public class EmployeeMapProfile : Profile
    {
        public EmployeeMapProfile()
        {
            CreateMap<EmployeeDto, Employee>();

            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<CreateEmployeeDto, Employee>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<CreateEmployeeDto, Employee>().ForMember(x => x.TenantId, opt => opt.Ignore());
        }
    }
}
