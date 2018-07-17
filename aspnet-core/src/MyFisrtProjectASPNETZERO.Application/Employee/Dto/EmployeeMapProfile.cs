using AutoMapper;


namespace MyFisrtProjectASPNETZERO.Employee.Dto
{
    public class EmployeeMapProfile : Profile
    {
        public EmployeeMapProfile()
        {
            CreateMap<EmployeeDto, MyFisrtProjectASPNETZERO.Employee1.Employee>();

            CreateMap<CreateEmployeeDto, MyFisrtProjectASPNETZERO.Employee1.Employee>();
            CreateMap<CreateEmployeeDto, MyFisrtProjectASPNETZERO.Employee1.Employee>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<CreateEmployeeDto, MyFisrtProjectASPNETZERO.Employee1.Employee>().ForMember(x => x.TenantId, opt => opt.Ignore());
        }
    }
}
