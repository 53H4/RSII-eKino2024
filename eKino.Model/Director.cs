using System;
using System.Collections.Generic;

namespace eKino.Model
{
    public partial class Director: SoftDeletableEntity
    {
        public int DirectorId { get; set; }
        public string FullName { get; set; }
        public string Biography { get; set; }
        public byte[] Photo { get; set; }

        public override string ToString()
        {
            return FullName;
        }
    }
}
