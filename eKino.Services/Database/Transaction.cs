using eKino.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace eKino.Services.Database
{
    public partial class Transaction : SoftDeletableEntity
    {
        public int TransactionId { get; set; }
        public DateTime DateOfTransaction { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public int ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; } = null!;
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }
    }
}
