using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using MyFisrtProjectASPNETZERO.Employee.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFisrtProjectASPNETZERO.Employee
{
    public class EmployeeAppService : AsyncCrudAppService<MyFisrtProjectASPNETZERO.Employee1.Employee, EmployeeDto, int, PagedResultRequestDto, CreateEmployeeDto, EmployeeDto>, IEmployeeAppService
    {

        private readonly IRepository<MyFisrtProjectASPNETZERO.Employee1.Employee> _employeeRepository;
        public EmployeeAppService(IRepository<MyFisrtProjectASPNETZERO.Employee1.Employee> employeeRepository) :base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        public async Task<ListResultDto<EmployeeDto>> GetAll1()
        {
            var employees = await _employeeRepository
                .GetAll()
                .OrderByDescending(x => x.CreationTime)
                .ToListAsync();


            var dtos = ObjectMapper.Map<List<EmployeeDto>>(employees);
            return await System.Threading.Tasks.Task.FromResult(new ListResultDto<EmployeeDto>(dtos));
        }
    }
}
