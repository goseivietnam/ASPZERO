using Abp.Authorization;
using MyFisrtProjectASPNETZERO.Authorization.Roles;
using MyFisrtProjectASPNETZERO.Authorization.Users;

namespace MyFisrtProjectASPNETZERO.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
