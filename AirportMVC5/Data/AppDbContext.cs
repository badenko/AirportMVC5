using AirportMVC5.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AirportMVC5.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Trip> Trips { get; set; }
    }
}