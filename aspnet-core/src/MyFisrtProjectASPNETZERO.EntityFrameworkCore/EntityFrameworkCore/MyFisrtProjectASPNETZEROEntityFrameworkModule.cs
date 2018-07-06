using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using MyFisrtProjectASPNETZERO.EntityFrameworkCore.Seed;

namespace MyFisrtProjectASPNETZERO.EntityFrameworkCore
{
    [DependsOn(
        typeof(MyFisrtProjectASPNETZEROCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class MyFisrtProjectASPNETZEROEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<MyFisrtProjectASPNETZERODbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        MyFisrtProjectASPNETZERODbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        MyFisrtProjectASPNETZERODbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyFisrtProjectASPNETZEROEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
