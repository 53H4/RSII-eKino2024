using System;
using System.Collections.Generic;

namespace eKino.Services.Database
{
    public partial class Auditorium: SoftDeletableEntity
    {
        public int AuditoriumId { get; set; }
        public string Name { get; set; } = null!;
    }
}
