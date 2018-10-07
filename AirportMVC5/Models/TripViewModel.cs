using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportMVC5.Models
{
    public class TripViewModel
    {
        public string Id { get; set; }
        public string Departure { get; set; }
        public string DepartureTerminal { get; set; }
        public string Arrival { get; set; }
        public string ArrivalTerminal { get; set; }
        public DateTime DepartureDay { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public DateTime ArrivalDay { get; set; }
        public TimeSpan ArrivalTime { get; set; }        
        public string FlightStatus { get; set; }
    }
}