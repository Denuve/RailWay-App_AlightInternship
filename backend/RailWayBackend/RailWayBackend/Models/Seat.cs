using System;
using System.ComponentModel.DataAnnotations;

namespace RailWayBackend.Models
{
    public class Seat
    {
        [Key]
        public Guid Id { get; set; }

        public Guid CarId { get; set; }

        public int SeatNumber { get; set; }

        public bool Free { get; set; }
    }
}