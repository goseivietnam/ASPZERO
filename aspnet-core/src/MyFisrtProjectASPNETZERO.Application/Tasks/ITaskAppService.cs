using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyFisrtProjectASPNETZERO.Tasks.Dto;
using System.Threading.Tasks;

namespace MyFisrtProjectASPNETZERO.Tasks
{
    public interface ITaskAppService:IApplicationService
    {
        Task<ListResultDto<TaskListDto>> GetAll(GetAllTasksInput input);
        Task<TaskListDto> Create(CreateTaskInput input);
    }
}
