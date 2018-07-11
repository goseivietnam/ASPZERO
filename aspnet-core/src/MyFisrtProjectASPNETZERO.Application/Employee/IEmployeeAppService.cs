using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyFisrtProjectASPNETZERO.Employee.Dto;

namespace MyFisrtProjectASPNETZERO.Employee
{
    public interface IEmployeeAppService : IAsyncCrudAppService<EmployeeDto, int, PagedResultRequestDto, CreateEmployeeDto, EmployeeDto>
    {
    }
}
