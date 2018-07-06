using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyFisrtProjectASPNETZERO.Configuration;

namespace MyFisrtProjectASPNETZERO.Web.Host.Startup
{
    [DependsOn(
       typeof(MyFisrtProjectASPNETZEROWebCoreModule))]
    public class MyFisrtProjectASPNETZEROWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MyFisrtProjectASPNETZEROWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyFisrtProjectASPNETZEROWebHostModule).GetAssembly());
        }
    }
}
