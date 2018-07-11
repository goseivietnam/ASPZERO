using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;

namespace MyFisrtProjectASPNETZERO.Employee
{
    public class Employee : Entity, IHasCreationTime
    {
        public DateTime CreationTime { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int? TenantId { get; set; }
    }
}
