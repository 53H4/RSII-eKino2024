using eKino.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace eKino.Services.Database
{
    public partial class Projection : SoftDeletableEntity
    {
        public Projection()
        {
            Reservations = new HashSet<Reservation>();
        }
        public int ProjectionId { get; set; }
        public DateTime DateOfProjection { get; set; }
        public int AuditoriumId { get; set; }
        public virtual Auditorium Auditorium { get; set; } = null!;
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; } = null!;
        [Column(TypeName = "decimal(10, 2)")]
        public decimal TicketPrice { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
