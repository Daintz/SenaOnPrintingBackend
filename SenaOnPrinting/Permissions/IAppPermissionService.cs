namespace SenaOnPrinting.Permissions
{
    public interface IAppPermissionService
    {
        Task<HashSet<String>> GetPermissionsAsync(long id);
    }
}
