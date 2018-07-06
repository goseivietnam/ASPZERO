using Microsoft.EntityFrameworkCore;
using MyFisrtProjectASPNETZERO.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace MyFisrtProjectASPNETZERO.EntityFrameworkCore.Seed.Tasks
{
    public class DefaultTasksBuilder
    {
        private readonly MyFisrtProjectASPNETZERODbContext _context;
        private readonly int _tenantId;

        public DefaultTasksBuilder(MyFisrtProjectASPNETZERODbContext context,int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            var tasks = new List<Task>
            { 
                new Task(_tenantId,"Task one","Do something"){State = TaskState.Open},
                new Task(_tenantId,"Task two","Do something else"){State = TaskState.Open},
                new Task(_tenantId,"Task three","I did this"){State = TaskState.Completed}
            };

            foreach(var task in tasks)
            {
                var existingTask = _context.Tasks.IgnoreQueryFilters().FirstOrDefault(x=>x.TenantId==task.TenantId&&x.Title == task.Title);
                if (existingTask == null)
                {
                    _context.Tasks.Add(task);
                }
            }
            _context.SaveChanges();
        }

    }
}
