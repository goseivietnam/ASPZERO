using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MyFisrtProjectASPNETZERO.EntityFrameworkCore
{
    public static class MyFisrtProjectASPNETZERODbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MyFisrtProjectASPNETZERODbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MyFisrtProjectASPNETZERODbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
