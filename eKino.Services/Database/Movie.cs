using eKino.Model;
using System;
using System.Collections.Generic;

namespace eKino.Services.Database
{
    public partial class Movie : SoftDeletableEntity
    {
        public Movie()
        {
            MovieGenres = new HashSet<MovieGenre>();
        }

        public int MovieId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Year { get; set; } = DateTime.Now.Year;
        public int RunningTime { get; set; }
        public byte[] Photo { get; set; } = null!;
        public int DirectorId { get; set; }
        public virtual Director Director { get; set; } = null!;
        public ICollection<MovieGenre> MovieGenres { get; set; } = null!;
    }
}
