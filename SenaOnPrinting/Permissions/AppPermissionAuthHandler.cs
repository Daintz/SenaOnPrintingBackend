using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace SenaOnPrinting.Permissions
{
    public class AppPermissionAuthHandler : AuthorizationHandler<AppPermissionRequirement>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public AppPermissionAuthHandler(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AppPermissionRequirement requirement)
        {
            string? userId = context.User.Claims.FirstOrDefault(
                x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if(!long.TryParse(userId, out var id))
            {
                return;
            }

            using IServiceScope scope = _serviceScopeFactory.CreateScope();

            IAppPermissionService service = scope.ServiceProvider.GetRequiredService<IAppPermissionService>();

            HashSet<String> appPermissions = await service.GetPermissionsAsync(id);

            if(appPermissions.Contains(requirement.AppPermission))
            {
                context.Succeed(requirement);
            }
        }
    }
}
