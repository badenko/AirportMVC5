using AirportMVC5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportMVC5.Domain
{
    public class TripsGenerator
    {
        private ITripRepository _tripRepository;
        private IFlightRepository _flightRepository;
        

        public TripsGenerator()
        {
            _tripRepository = new TripRepository();
            _flightRepository = new FlightRepository();
        }

        public void GenerateTrips()
        {
            var flights = _flightRepository.GetAll();
            Random random = new Random();            

            foreach (Flight flight in flights)
            {
                for (int i = 0; i < 3; i++)
                {
                    DateTime currentDate = DateTime.Today;
                    currentDate = currentDate.AddDays(i);
                    DateTime checker = currentDate;
                    TimeSpan currentFlightTime = flight.ArrivalTime - flight.DepartureTime;
                    if ((flight.ArrivalTime - flight.DepartureTime) < new TimeSpan(0,0,0))
                    {
                        currentFlightTime = new TimeSpan(24, 0, 0) + currentFlightTime;
                        checker = currentDate.AddDays(1);
                    }

                    Trip trip = new Trip
                    {
                        Departure = flight.DeparturePoint,
                        DepartureTerminal = string.Concat((char)random.Next('A', 'F' + 1).GetHashCode()),
                        Arrival = flight.ArrivalPoint,
                        ArrivalTerminal = string.Concat((char)random.Next('A', 'F' + 1).GetHashCode()),
                        DepartureDay = currentDate,
                        DepartureTime = flight.DepartureTime.TimeOfDay,
                        ArrivalDay = checker,
                        ArrivalTime = flight.ArrivalTime.TimeOfDay,
                        FlightTime = currentFlightTime,
                        FlightStatus = (FlightStatus)random.Next(1,8)
                    };
                    _tripRepository.AddTrip(trip);
                }
            }
        }

        
    }
}