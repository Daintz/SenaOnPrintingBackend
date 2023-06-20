using DataCape.Models;
using Microsoft.AspNetCore.Authorization;
using PersistenceCape.Contexts;

namespace SenaOnPrinting.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizationFilter : AuthorizeAttribute
    {
        private readonly UserModel _user;
        private readonly SENAONPRINTINGContext _context;
        private int idAppPermission;

        public AuthorizationFilter(UserModel user, SENAONPRINTINGContext context, int idAppPermission = 0)
        {
            _user = user;
            _context = context;
            this.idAppPermission = idAppPermission;
        }

        public void OnAuthorization(AuthorizationHandlerContext context)
        {
            
        }
    }
}
