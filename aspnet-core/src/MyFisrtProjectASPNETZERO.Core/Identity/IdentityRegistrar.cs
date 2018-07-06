using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MyFisrtProjectASPNETZERO.Authorization;
using MyFisrtProjectASPNETZERO.Authorization.Roles;
using MyFisrtProjectASPNETZERO.Authorization.Users;
using MyFisrtProjectASPNETZERO.Editions;
using MyFisrtProjectASPNETZERO.MultiTenancy;

namespace MyFisrtProjectASPNETZERO.Identity
{
    public static class IdentityRegistrar
    {
        public static IdentityBuilder Register(IServiceCollection services)
        {
            services.AddLogging();

            return services.AddAbpIdentity<Tenant, User, Role>()
                .AddAbpTenantManager<TenantManager>()
                .AddAbpUserManager<UserManager>()
                .AddAbpRoleManager<RoleManager>()
                .AddAbpEditionManager<EditionManager>()
                .AddAbpUserStore<UserStore>()
                .AddAbpRoleStore<RoleStore>()
                .AddAbpLogInManager<LogInManager>()
                .AddAbpSignInManager<SignInManager>()
                .AddAbpSecurityStampValidator<SecurityStampValidator>()
                .AddAbpUserClaimsPrincipalFactory<UserClaimsPrincipalFactory>()
                .AddPermissionChecker<PermissionChecker>()
                .AddDefaultTokenProviders();
        }
    }
}
