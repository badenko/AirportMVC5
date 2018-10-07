using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirportMVC5.Data;
using AirportMVC5.Domain;

namespace AirportMVC5.Repository
{
    public class FlightRepository : IFlightRepository
    {
        private AppDbContext _context;

        public FlightRepository()
        {
            _context = new AppDbContext();
        }

        public void AddFlight(Flight flight)
        {
            _context.Flights.Add(flight);

            _context.SaveChanges();
        }

        public List<Flight> GetAll()
        {
            return _context.Flights.ToList();
        }

        public Flight GetById(int id)
        {
            return _context.Flights.FirstOrDefault(_ => _.Id == id);
        }

        public void RemoveFlight(int id)
        {
            Flight flight = _context.Flights.FirstOrDefault(_ => _.Id == id);
            _context.Flights.Remove(flight);

            _context.SaveChanges();
        }

        public void UpdateFlight(Flight flight)
        {
            Flight flightToUpdate = _context.Flights.FirstOrDefault(_ => _.Id == flight.Id);

            flightToUpdate.DeparturePoint = flight.DeparturePoint;
            flightToUpdate.ArrivalPoint = flight.ArrivalPoint;
            flightToUpdate.DepartureTime = flight.DepartureTime;
            flightToUpdate.ArrivalTime = flight.ArrivalTime;

            _context.SaveChanges();
        }
    }
}