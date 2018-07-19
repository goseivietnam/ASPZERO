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
        private readonly IRepository<MyFisrtProjectASPNETZERO.Tasks.Task> _taskRepository;
        public EmployeeAppService(IRepository<MyFisrtProjectASPNETZERO.Employee1.Employee> employeeRepository, IRepository<MyFisrtProjectASPNETZERO.Tasks.Task> taskRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _taskRepository = taskRepository;
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

        public List<EmployeeDto1> GetAll2()
        {
            var tasks = _taskRepository.GetAll();
            var employees = _employeeRepository.GetAll();
            var result = (from e in employees
                          select new
                          {
                              e.Id,
                              e.CreationTime,
                              e.Name,
                              e.Birthday,
                              PendingTask= (from t in tasks where t.EmployeeId==e.Id && t.State==0 select t).Count(),
                              CompletedTask= (from t in tasks where t.EmployeeId == e.Id && t.State == Tasks.TaskState.Completed select t).Count()
                          }
                          ).ToList();


                var dtos = ObjectMapper.Map<List<EmployeeDto1>>(result);
            return dtos;
        }

    }
}
