using System;
using System.Collections.Generic;
using System.Text;

namespace eKino.Model
{
    public class SoftDeletableEntity
    {
        public bool IsDeleted { get; set; } = false;
    }
}
