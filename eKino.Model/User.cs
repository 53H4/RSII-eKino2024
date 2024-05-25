using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace eKino.Model
{
    public partial class User : SoftDeletableEntity
    {
    
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        public string RoleNames => string.Join(", " ,UserRoles?.Select(x => x.Role?.Name)?.ToList());

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

    }
}
