using eKino.Model;
using System;
using System.Collections.Generic;

namespace eKino.Model
{
    public partial class Movie : SoftDeletableEntity
    {

        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; } = DateTime.Now.Year;
        public int RunningTime { get; set; }
        public byte[] Photo { get; set; }
        public int DirectorId { get; set; }
        public virtual Director Director { get; set; }
        public ICollection<MovieGenre> MovieGenres { get; set; }
        public override string ToString()
        {
            return Title;
        }
    }
}
