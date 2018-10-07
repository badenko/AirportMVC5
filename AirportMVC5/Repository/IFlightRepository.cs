using AirportMVC5.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportMVC5.Repository
{
    interface IFlightRepository
    {
        List<Flight> GetAll();
        Flight GetById(int id);
        void AddFlight(Flight flight);
        void RemoveFlight(int id);
        void UpdateFlight(Flight flight);
    }
}