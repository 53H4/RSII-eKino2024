using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eKino.Model.Requests
{
    public class ReservationUpsertRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ProjectionId { get; set; }
        [Required]
        public int Row { get; set; }
        [Required]
        public int Column { get; set; }
        [Required]
        [Range(minimum: 1, maximum: 10)]
        public int NumTickets { get; set; }
    }
}
