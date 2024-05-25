using System;
using System.Collections.Generic;

namespace eKino.Model
{
    public partial class Genre : SoftDeletableEntity
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
