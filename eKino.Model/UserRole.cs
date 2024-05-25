using System;
using System.Collections.Generic;

namespace eKino.Model
{
    public partial class UserRole
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime DateModified { get; set; }
        public virtual Role Role { get; set; }
    }
}
