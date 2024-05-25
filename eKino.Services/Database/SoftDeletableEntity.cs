using System;
using System.Collections.Generic;
using System.Text;

namespace eKino.Services.Database
{
    public class SoftDeletableEntity
    {
        public bool IsDeleted { get; set; } = false;
    }
}
