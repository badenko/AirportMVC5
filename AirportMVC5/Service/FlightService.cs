using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirportMVC5.Domain;
using AirportMVC5.Models;
using AirportMVC5.Repository;

namespace AirportMVC5.Service
{
    public class FlightService : IFlightService
    {
        private IFlightRepository _flightRpository;
        private IHashIdsService _hashidService;

        public FlightService()
        {
            _flightRpository = new FlightRepository();
            _hashidService = new HashidService();
        }

        public void AddNewFlight(FlightViewModel model)
        {
            Flight flight = new Flight
            {
                DeparturePoint = model.DeparturePoint,
                DepartureTime = model.DepartureTime,
                ArrivalPoint = model.ArrivalPoint,
                ArrivalTime = model.ArrivalTime
            };

            if (flight.DepartureTime == null) flight.DepartureTime = new DateTime(0, 0, 0, 0, 0, 0);
            if (flight.ArrivalTime == null) flight.ArrivalTime = new DateTime(0, 0, 0, 0, 0, 0);

            _flightRpository.AddFlight(flight);
        }

        public List<FlightViewModel> GetAll()
        {
            var flights = _flightRpository.GetAll();

            return flights.Select(_ => new FlightViewModel
            {
                Id = _hashidService.Encrypt(_.Id),
                DeparturePoint = _.DeparturePoint,
                DepartureTime = _.DepartureTime,
                ArrivalPoint = _.ArrivalPoint,
                ArrivalTime = _.ArrivalTime
            }).ToList();
        }

        public FlightViewModel GetById(string id)
        {
            int decryptedId = _hashidService.Decrypt(id);
            Flight flight = _flightRpository.GetById(decryptedId);

            return new FlightViewModel
            {
                DeparturePoint = flight.DeparturePoint,
                DepartureTime = flight.DepartureTime,
                ArrivalPoint = flight.ArrivalPoint,
                ArrivalTime = flight.ArrivalTime
            };
        }

        public void RemoveFlight(string id)
        {
            int decryptedId = _hashidService.Decrypt(id);
            _flightRpository.RemoveFlight(decryptedId);
        }

        public void UpdateFlight(FlightViewModel model)
        {
            int decryptedId = _hashidService.Decrypt(model.Id);

            Flight flight = new Flight
            {
                Id = decryptedId,
                DeparturePoint = model.DeparturePoint,
                DepartureTime = model.DepartureTime,
                ArrivalPoint = model.ArrivalPoint,
                ArrivalTime = model.ArrivalTime
            };
            _flightRpository.UpdateFlight(flight);

        }



    }
}