using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportMVC5.Models
{
    public class FlightViewModel
    {
        public string Id { get; set; }
        public string DeparturePoint { get; set; }
        public string ArrivalPoint { get; set; }
        public DateTime DepartureTime { get; set; }        
        public DateTime ArrivalTime { get; set; }        
    }
}