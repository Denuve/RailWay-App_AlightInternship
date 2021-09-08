using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Backend_Final.Models;

namespace Backend_Final.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() :
        base("RailWayConnectionString")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Train> Trains { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Seat> Seats { get; set; }
    }
}