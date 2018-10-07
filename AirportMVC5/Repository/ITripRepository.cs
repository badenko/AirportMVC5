using AirportMVC5.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportMVC5.Repository
{
    interface ITripRepository
    {
        List<Trip> GetAll();
        Trip GetById(int id);
        
        void UpdateFlightStatus(Trip trip);
        void AddTrip(Trip trip);
        
    }
}