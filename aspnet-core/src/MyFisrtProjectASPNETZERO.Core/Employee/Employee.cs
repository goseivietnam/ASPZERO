using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using MyFisrtProjectASPNETZERO.Tasks;
using System;
using System.Collections.Generic;

namespace MyFisrtProjectASPNETZERO.Employee1
{
    public class Employee : Entity, IHasCreationTime
    {
        public DateTime CreationTime { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int? TenantId { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
