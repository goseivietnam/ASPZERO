using AutoMapper;

namespace MyFisrtProjectASPNETZERO.Tasks.Dto
{
    public class TaskMapProfile: Profile
    {
       public TaskMapProfile()
        {
            CreateMap<CreateTaskInput,Task>();
            CreateMap<CreateTaskInput,Task>().ForMember(x=>x.TenantId,opt=>opt.Ignore());
            CreateMap<CreateTaskInput, Task>();
            CreateMap<CreateTaskInput, Task>().ForMember(x => x.CreationTime, opt => opt.Ignore());
            CreateMap<CreateTaskInput, Task>();
            CreateMap<CreateTaskInput, Task>().ForMember(x => x.State, opt => opt.Ignore());
        }
    }
}
