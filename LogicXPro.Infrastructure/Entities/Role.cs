using System.Collections.Generic;

namespace LogicXPro.Infrastructure.Entities
{
    public class Role
    {
        public int RoleID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }
    }
}
