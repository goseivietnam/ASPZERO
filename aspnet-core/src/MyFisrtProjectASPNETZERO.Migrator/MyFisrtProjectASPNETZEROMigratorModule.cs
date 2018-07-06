using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyFisrtProjectASPNETZERO.Configuration;
using MyFisrtProjectASPNETZERO.EntityFrameworkCore;
using MyFisrtProjectASPNETZERO.Migrator.DependencyInjection;

namespace MyFisrtProjectASPNETZERO.Migrator
{
    [DependsOn(typeof(MyFisrtProjectASPNETZEROEntityFrameworkModule))]
    public class MyFisrtProjectASPNETZEROMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public MyFisrtProjectASPNETZEROMigratorModule(MyFisrtProjectASPNETZEROEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(MyFisrtProjectASPNETZEROMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                MyFisrtProjectASPNETZEROConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyFisrtProjectASPNETZEROMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
