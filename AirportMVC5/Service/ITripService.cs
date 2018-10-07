using AirportMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportMVC5.Service
{
    interface ITripService
    {
        List<TripViewModel> GetAll();
        TripViewModel GetById(string id);
        
        void UpdateFlightStatus(TripViewModel model);
        void CancelFlight(TripViewModel model);
    }
}
