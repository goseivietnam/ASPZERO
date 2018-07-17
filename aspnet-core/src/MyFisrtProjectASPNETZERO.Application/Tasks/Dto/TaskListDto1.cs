using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;

namespace MyFisrtProjectASPNETZERO.Tasks.Dto
{

    public class TaskListDto1
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public DateTime CreationTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskState State { get; set; }
        public string Name { get; set; }
    }
}
