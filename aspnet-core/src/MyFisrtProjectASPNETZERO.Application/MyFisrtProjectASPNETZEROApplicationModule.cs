using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyFisrtProjectASPNETZERO.Authorization;

namespace MyFisrtProjectASPNETZERO
{
    [DependsOn(
        typeof(MyFisrtProjectASPNETZEROCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MyFisrtProjectASPNETZEROApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MyFisrtProjectASPNETZEROAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MyFisrtProjectASPNETZEROApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
