using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyFisrtProjectASPNETZERO.Configuration;
using MyFisrtProjectASPNETZERO.Web;

namespace MyFisrtProjectASPNETZERO.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MyFisrtProjectASPNETZERODbContextFactory : IDesignTimeDbContextFactory<MyFisrtProjectASPNETZERODbContext>
    {
        public MyFisrtProjectASPNETZERODbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MyFisrtProjectASPNETZERODbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MyFisrtProjectASPNETZERODbContextConfigurer.Configure(builder, configuration.GetConnectionString(MyFisrtProjectASPNETZEROConsts.ConnectionStringName));

            return new MyFisrtProjectASPNETZERODbContext(builder.Options);
        }
    }
}
