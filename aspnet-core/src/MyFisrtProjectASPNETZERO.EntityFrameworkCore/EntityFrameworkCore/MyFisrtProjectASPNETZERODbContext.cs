using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyFisrtProjectASPNETZERO.Authorization.Roles;
using MyFisrtProjectASPNETZERO.Authorization.Users;
using MyFisrtProjectASPNETZERO.MultiTenancy;
using MyFisrtProjectASPNETZERO.Tasks.Configuration;
using MyFisrtProjectASPNETZERO.Tasks;

namespace MyFisrtProjectASPNETZERO.EntityFrameworkCore
{
    public class MyFisrtProjectASPNETZERODbContext : AbpZeroDbContext<Tenant, Role, User, MyFisrtProjectASPNETZERODbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Task> Tasks { get;set;}
        
        public MyFisrtProjectASPNETZERODbContext(DbContextOptions<MyFisrtProjectASPNETZERODbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            TaskEntityConfiguration.Configure(modelBuilder.Entity<Task>());
        }
    }
}
