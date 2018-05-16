using Abp.Authorization;
using CloudBaseLine.Authorization.Roles;
using CloudBaseLine.Authorization.Users;

namespace CloudBaseLine.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
