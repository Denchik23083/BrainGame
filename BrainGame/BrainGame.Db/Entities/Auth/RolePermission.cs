using BrainGame.Core.Utilities;

namespace BrainGame.Db.Entities.Auth
{
    public class RolePermission
    {
        public int Id { get; set; }

        public int? RoleId { get; set; }
        
        public Role? Role { get; set; }

        public PermissionType? PermissionType { get; set; }
    }
}
