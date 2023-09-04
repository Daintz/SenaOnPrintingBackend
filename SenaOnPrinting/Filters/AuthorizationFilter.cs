using DataCape.Models;
using Microsoft.AspNetCore.Authorization;
using SenaOnPrinting.Permissions;

namespace SenaOnPrinting.Filters
{    
    public sealed class AuthorizationFilterAttribute : AuthorizeAttribute
    {        public AuthorizationFilterAttribute(ApplicationPermission appPermission) : base(policy: appPermission.ToString())
        {
            
        }
    }
}
