using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eKino.Model.Requests
{
    public class MovieUpsertRequest
    {

        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }
        [Required]
        [Range(minimum: 1900, maximum: 2100)]
        public int Year { get; set; } = DateTime.Now.Year;
        [Required]
        public int RunningTime { get; set; }
        public byte[] Photo { get; set; }
        [Required]
        public int DirectorId { get; set; }
        public List<int> MovieGenreIdList { get; set; } = new List<int> { };
    }
}
