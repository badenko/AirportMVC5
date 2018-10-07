using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportMVC5.Domain
{
    public class Trip
    {
        public int Id { get; set; }
        public string Departure { get; set; }
        public string DepartureTerminal { get; set; }
        public string Arrival { get; set; }
        public string ArrivalTerminal { get; set; }
        public DateTime DepartureDay { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public DateTime ArrivalDay { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan FlightTime { get; set; }
        public FlightStatus FlightStatus { get; set; }
    }

    public enum FlightStatus
    {
        CheckIn,
        GateClosed,
        Arrived,
        DepartedAt,
        Unknown,
        Cancelled,
        ExpectedAt,
        Delayed,
        InFlight,
    }
}