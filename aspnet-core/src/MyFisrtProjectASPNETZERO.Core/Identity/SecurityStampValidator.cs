using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using MyFisrtProjectASPNETZERO.Authorization.Roles;
using MyFisrtProjectASPNETZERO.Authorization.Users;
using MyFisrtProjectASPNETZERO.MultiTenancy;

namespace MyFisrtProjectASPNETZERO.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
            IOptions<SecurityStampValidatorOptions> options, 
            SignInManager signInManager,
            ISystemClock systemClock) 
            : base(
                  options, 
                  signInManager, 
                  systemClock)
        {
        }
    }
}
