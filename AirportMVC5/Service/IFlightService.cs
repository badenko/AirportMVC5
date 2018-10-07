using AirportMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportMVC5.Service
{
    interface IFlightService
    {
        List<FlightViewModel> GetAll();
        FlightViewModel GetById(string id);

        void AddNewFlight(FlightViewModel model);
        void RemoveFlight(string id);
        void UpdateFlight(FlightViewModel model);

    }
}
