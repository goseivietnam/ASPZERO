using Abp.MultiTenancy;
using MyFisrtProjectASPNETZERO.Authorization.Users;

namespace MyFisrtProjectASPNETZERO.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
