using eKino.Model;
using System;
using System.Collections.Generic;

namespace eKino.Model
{
    public partial class Reservation : SoftDeletableEntity
    {
        public int ReservationId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int ProjectionId { get; set; }
        public virtual Projection Projection { get; set; }
        public DateTime DateOfReservation { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int NumTickets { get; set; }
    }
}
