using eKino.Model;
using System;
using System.Collections.Generic;

namespace eKino.Services.Database
{
    public partial class Reservation : SoftDeletableEntity
    {
        public int ReservationId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public int ProjectionId { get; set; }
        public virtual Projection Projection { get; set; } = null!;
        public DateTime DateOfReservation { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int NumTickets { get; set; }
    }
}
