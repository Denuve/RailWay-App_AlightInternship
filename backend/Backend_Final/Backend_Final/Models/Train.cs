using System;
using System.ComponentModel.DataAnnotations;

namespace Backend_Final.Models
{
    public class Train
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DayOfWeek { get; set; }
    }
}