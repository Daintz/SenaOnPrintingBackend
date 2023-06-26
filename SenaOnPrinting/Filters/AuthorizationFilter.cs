using DataCape.Models;
using Microsoft.AspNetCore.Authorization;
using PersistenceCape.Contexts;
using SenaOnPrinting.Permissions;

namespace SenaOnPrinting.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizationFilter : AuthorizeAttribute
    {        public AuthorizationFilter(ApplicationPermission appPermission) : base(policy: appPermission.ToString())
        {
            
        }
    }
}
