using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using MyFisrtProjectASPNETZERO.Tasks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFisrtProjectASPNETZERO.Tasks
{
    public class TaskAppService : MyFisrtProjectASPNETZEROAppServiceBase, ITaskAppService
    {
        private readonly IRepository<Task> _taskRepository;
        private readonly IRepository<MyFisrtProjectASPNETZERO.Employee1.Employee> _employeeRepository;

        public TaskAppService(IRepository<Task> taskRepository, IRepository<MyFisrtProjectASPNETZERO.Employee1.Employee> employeeRepository)
        {
            _taskRepository = taskRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<ListResultDto<TaskListDto>> GetAll(GetAllTasksInput input)
        {
            var tasks = await _taskRepository
                .GetAll()                
                .WhereIf(input.TaskState.HasValue,x=>x.State==input.TaskState.Value)
                .OrderByDescending(x => x.CreationTime)
                .ToListAsync();
                

            var dtos = ObjectMapper.Map<List<TaskListDto>>(tasks);
            return await System.Threading.Tasks.Task.FromResult(new ListResultDto<TaskListDto>(dtos));
        }

        public List<TaskListDto1> GetAll1()
        {
            var tasks =  _taskRepository.GetAll();
            var employees = _employeeRepository.GetAll();
            var result = (from t in tasks
                          join e in  employees
                          on t.EmployeeId equals e.Id into a
                          from e in a.DefaultIfEmpty()
                          select new{t.Id,t.TenantId,t.CreationTime,t.Title,t.Description,t.State,e.Name }).ToList();


            var dtos = ObjectMapper.Map<List<TaskListDto1>>(result);
            return dtos;
        }

        public async Task<TaskListDto> Create(CreateTaskInput input)
        {
                var task = ObjectMapper.Map<Task>(input);
                task.TenantId = 2;
                await _taskRepository.InsertAsync(task);
                await CurrentUnitOfWork.SaveChangesAsync();

                return ObjectMapper.Map<TaskListDto>(task);
        }

        public async Task<TaskListDto> Update(TaskListDto input)
        {
            try
            {
                var task = _taskRepository.Get(input.Id);
                ObjectMapper.Map(input, task);
                var result = await _taskRepository.UpdateAsync(task);

                return ObjectMapper.Map<TaskListDto>(result);
            }
            catch(Exception e)
            {
                throw e;
            }
           
        }
        public  async void Delete(int id)
        {
            try
            {
                var task = _taskRepository.Get(id);
                await _taskRepository.DeleteAsync(task);
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }

        public async Task<TaskListDto> GetAsync(int id)
        {
             var a = ObjectMapper.Map<TaskListDto>(_taskRepository.Get(id));
            return await System.Threading.Tasks.Task.FromResult(a);
        }
    }
}
