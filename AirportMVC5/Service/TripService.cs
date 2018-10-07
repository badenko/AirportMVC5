using AirportMVC5.Domain;
using AirportMVC5.Models;
using AirportMVC5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportMVC5.Service
{
    public class TripService : ITripService
    {
        private ITripRepository _tripRepository;
        private IHashIdsService _hashIdsService;

        public TripService()
        {
            _tripRepository = new TripRepository();
            _hashIdsService = new HashidService();
        }

       

        public List<TripViewModel> GetAll()
        {
            var trips = _tripRepository.GetAll();

            return trips.Select(_ => new TripViewModel
            {
                Id = _hashIdsService.Encrypt(_.Id),
                Departure = _.Departure,
                DepartureTerminal = _.DepartureTerminal,
                DepartureDay = _.DepartureDay,
                DepartureTime = _.DepartureTime,
                Arrival = _.Arrival,
                ArrivalTerminal = _.ArrivalTerminal,
                ArrivalDay = _.ArrivalDay,
                ArrivalTime = _.ArrivalTime,
                FlightStatus = _.FlightStatus.ToString()
            }).ToList();
        }

        public TripViewModel GetById(string id)
        {
            var decryptedId = _hashIdsService.Decrypt(id);
            Trip trip = _tripRepository.GetById(decryptedId);

            return new TripViewModel
            {

                Departure = trip.Departure,
                DepartureTerminal = trip.DepartureTerminal,
                DepartureDay = trip.DepartureDay,
                DepartureTime = trip.DepartureTime,
                Arrival = trip.Arrival,
                ArrivalTerminal = trip.ArrivalTerminal,
                ArrivalDay = trip.ArrivalDay,
                ArrivalTime = trip.ArrivalTime,
                FlightStatus = trip.FlightStatus.ToString()
            };
        }

        public void UpdateFlightStatus(TripViewModel model)
        {
            int decryptedId = _hashIdsService.Decrypt(model.Id);
            var a = Convert.ToInt32(model.FlightStatus);
            Trip trip = new Trip
            {
                Id = decryptedId,
                FlightStatus = (FlightStatus)Convert.ToInt32(model.FlightStatus)
            };
            _tripRepository.UpdateFlightStatus(trip);
        }

        public void CancelFlight(TripViewModel model)
        {
            int decryptedId = _hashIdsService.Decrypt(model.Id);
            Trip trip = new Trip
            {
                Id = decryptedId,
                FlightStatus = FlightStatus.Cancelled
            };
            _tripRepository.UpdateFlightStatus(trip);
        }
    }
}