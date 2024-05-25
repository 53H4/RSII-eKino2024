using System;
using System.Collections.Generic;

namespace eKino.Services.Database
{
    public partial class Genre : SoftDeletableEntity
    {
        public int GenreId { get; set; }
        public string Name { get; set; } = null!;
    }
}
