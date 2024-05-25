using System;
using System.Collections.Generic;
using System.Text;

namespace eKino.Model.SearchObjects
{
    public class UserSearchObject : BaseSearchObject
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public bool IncludeRoles { get; set; }
        public string Name { get; set; }
    }
}
