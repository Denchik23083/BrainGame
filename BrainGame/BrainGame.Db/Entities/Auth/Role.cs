using BrainGame.Core.Utilities;

namespace BrainGame.Db.Entities.Auth
{
    public class Role
    {
        public int Id { get; set; }

        public RoleType? RoleType { get; set; }
        
        public List<RolePermission>? RolePermissions { get; set; }        
    }
}
