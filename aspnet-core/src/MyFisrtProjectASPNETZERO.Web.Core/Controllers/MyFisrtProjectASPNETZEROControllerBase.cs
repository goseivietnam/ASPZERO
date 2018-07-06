using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MyFisrtProjectASPNETZERO.Controllers
{
    public abstract class MyFisrtProjectASPNETZEROControllerBase: AbpController
    {
        protected MyFisrtProjectASPNETZEROControllerBase()
        {
            LocalizationSourceName = MyFisrtProjectASPNETZEROConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
