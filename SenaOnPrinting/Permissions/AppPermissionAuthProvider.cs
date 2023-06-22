using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace SenaOnPrinting.Permissions
{
    public class AppPermissionAuthProvider : DefaultAuthorizationPolicyProvider
    {
        public AppPermissionAuthProvider(IOptions<AuthorizationOptions> options) : base(options)
        {
        }

        public override async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {
            AuthorizationPolicy? policy = await base.GetPolicyAsync(policyName);

            if(policy != null)
            {
                return policy;
            }

            return new AuthorizationPolicyBuilder().AddRequirements(new AppPermissionRequirement(policyName)).Build();
        }
    }
}
