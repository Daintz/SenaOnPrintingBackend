using Microsoft.AspNetCore.Authorization;

namespace SenaOnPrinting.Permissions
{
    public class AppPermissionRequirement : IAuthorizationRequirement
    {
        public AppPermissionRequirement(string appPermission)
        {
            AppPermission = appPermission;
        }
        public String AppPermission { get; }
    }
}
