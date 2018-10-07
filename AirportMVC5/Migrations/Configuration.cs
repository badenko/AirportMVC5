namespace AirportMVC5.Migrations
{
    using AirportMVC5.Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AirportMVC5.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AirportMVC5.Data.AppDbContext context)
        {

            context.Flights.Add(new Flight { DeparturePoint = "Kyiv", DepartureTime = new DateTime(2018, 1, 1, 15, 10, 0), ArrivalPoint = "London", ArrivalTime = new DateTime(2018, 1, 1, 1, 1, 0) + new TimeSpan(3, 45, 00) });
            context.Flights.Add(new Flight { DeparturePoint = "Kyiv", DepartureTime = new DateTime(2018, 1, 1, 16, 31, 0), ArrivalPoint = "Munich", ArrivalTime = new DateTime(2018, 1, 1, 1, 1, 0) + new TimeSpan(3, 00, 00) });
            context.Flights.Add(new Flight { DeparturePoint = "Munich", DepartureTime = new DateTime(2018, 1, 1, 12, 1, 0), ArrivalPoint = "Moscow", ArrivalTime = new DateTime(2018, 1, 1, 1, 1, 0) + new TimeSpan(2, 45, 00) });
            context.Flights.Add(new Flight { DeparturePoint = "Vienna", DepartureTime = new DateTime(2018, 1, 1, 3, 41, 0), ArrivalPoint = "Dnepr", ArrivalTime = new DateTime(2018, 1, 1, 1, 1, 0) + new TimeSpan(1, 15, 00) });
            context.Flights.Add(new Flight { DeparturePoint = "Odessa", DepartureTime = new DateTime(2018, 1, 1, 5, 1, 0), ArrivalPoint = "Istanbul", ArrivalTime = new DateTime(2018, 1, 1, 1, 1, 0) + new TimeSpan(4, 40, 00) });
            context.Flights.Add(new Flight { DeparturePoint = "Lisbon", DepartureTime = new DateTime(2018, 1, 1, 1, 51, 0), ArrivalPoint = "London", ArrivalTime = new DateTime(2018, 1, 1, 1, 1, 0) + new TimeSpan(3, 15, 00) });
            context.Flights.Add(new Flight { DeparturePoint = "Hell", DepartureTime = new DateTime(2018, 1, 1, 1, 7, 0), ArrivalPoint = "Paris", ArrivalTime = new DateTime(2018, 1, 1, 1, 1, 0) + new TimeSpan(7, 45, 00) });
            context.Flights.Add(new Flight { DeparturePoint = "Komishevaha", DepartureTime = new DateTime(2018, 1, 1, 1, 1, 0), ArrivalPoint = "Vidubichi", ArrivalTime = new DateTime(2018, 1, 1, 1, 1, 0) + new TimeSpan(6, 45, 00) });
            context.Flights.Add(new Flight { DeparturePoint = "Tuda", DepartureTime = new DateTime(2018, 1, 1, 15, 18, 0), ArrivalPoint = "Suda", ArrivalTime = new DateTime(2018, 1, 1, 1, 1, 0) + new TimeSpan(3, 45, 00) });
            context.SaveChanges();
            TripsGenerator tripsGenerator = new TripsGenerator();
            tripsGenerator.GenerateTrips();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
