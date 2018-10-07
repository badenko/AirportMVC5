using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirportMVC5.Data;
using AirportMVC5.Domain;

namespace AirportMVC5.Repository
{
    public class TripRepository : ITripRepository
    {
        private AppDbContext _context;

        public TripRepository()
        {
            _context = new AppDbContext();
        }

        public void AddTrip(Trip trip)
        {
            _context.Trips.Add(trip);
            _context.SaveChanges();
        }

        public void CancelTrip(Trip trip)
        {
            throw new NotImplementedException();
        }

        public List<Trip> GetAll()
        {
            return _context.Trips.ToList();
        }

        public Trip GetById(int id)
        {
            return _context.Trips.FirstOrDefault(_ => _.Id == id);
        }

        public void UpdateFlightStatus(Trip newTrip)
        {
            Trip oldTrip = _context.Trips.FirstOrDefault(_ => _.Id == newTrip.Id);

            oldTrip.FlightStatus = newTrip.FlightStatus;

            _context.SaveChanges();
        }
        
    }
}