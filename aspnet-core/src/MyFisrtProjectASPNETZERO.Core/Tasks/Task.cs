using System;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace MyFisrtProjectASPNETZERO.Tasks
{
    public class Task : Entity, IMustHaveTenant, IHasCreationTime
    {
        public int TenantId { get;set;}
        public DateTime CreationTime {get;set;}
        public string Title { get;set;}
        public string Description { get;set;}
        public TaskState State { get;set;}

        public Task()
        {
            CreationTime = Clock.Now;
            State = TaskState.Open;
        }
        public Task(int tenantId,string title, string description = null) : this()
        {
            TenantId = tenantId;
            Title = title;
            Description = description;
        }
    }
}
