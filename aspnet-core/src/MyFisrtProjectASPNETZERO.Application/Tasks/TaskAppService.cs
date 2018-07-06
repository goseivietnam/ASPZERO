using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using MyFisrtProjectASPNETZERO.Tasks.Dto;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace MyFisrtProjectASPNETZERO.Tasks
{
    public class TaskAppService : MyFisrtProjectASPNETZEROAppServiceBase, ITaskAppService
    {
        private readonly IRepository<Task> _taskRepository;

        public TaskAppService(IRepository<Task> taskRepository)
        {
            _taskRepository = taskRepository;
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

        public async Task<TaskListDto> Create(CreateTaskInput input)
        {
            var task = ObjectMapper.Map<Task>(input);
            await _taskRepository.InsertAsync(task);
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<TaskListDto>(task);
        }
    }
}
