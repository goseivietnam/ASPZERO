using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using MyFisrtProjectASPNETZERO.Employee.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFisrtProjectASPNETZERO.Employee
{
    public class EmployeeAppService : AsyncCrudAppService<Employee, EmployeeDto, int, PagedResultRequestDto, CreateEmployeeDto, EmployeeDto>, IEmployeeAppService
    {

        private readonly IRepository<Employee> _employeeRepository;
        public EmployeeAppService(IRepository<Employee> employeeRepository) :base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


    }
}
