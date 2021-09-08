using System;
using System.ComponentModel.DataAnnotations;

namespace Backend_Final.Models
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; }

        public Guid TrainId { get; set; }

        public int NumberOfSeats { get; set; }

        public string Type { get; set; }

    }
}