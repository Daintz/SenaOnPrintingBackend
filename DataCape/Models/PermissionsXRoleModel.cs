namespace DataCape.Models
{
    public partial class PermissionsXRoleModel
    {
        public long IdPermission { get; set; }
        public long IdRole { get; set; }

        public virtual PermissionModel IdPermissionNavigation { get; set; } = null!;
        public virtual Role IdRoleNavigation { get; set; } = null!;
    }
}
