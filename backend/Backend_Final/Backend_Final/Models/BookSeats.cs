using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Backend_Final.Models
{
    public class BookSeats
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime Date { get; set; }

        public string CNP { get; set; }

        public string BookingCode { get; set; }


    }
}