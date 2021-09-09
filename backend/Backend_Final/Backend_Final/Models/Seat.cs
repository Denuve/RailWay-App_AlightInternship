using System;
using System.ComponentModel.DataAnnotations;


namespace Backend_Final.Models
{
    public class Seat
    {
        [Key]
        public Guid Id { get; set; }

        public Guid CarId { get; set; }

        public int SeatNumber { get; set; }

        public bool Occupied { get; set; }

        public Guid BookingId { get; set; }
    }
}