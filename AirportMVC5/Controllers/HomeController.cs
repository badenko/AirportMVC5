using AirportMVC5.Models;
using AirportMVC5.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirportMVC5.Controllers
{
    public class HomeController : Controller
    {
        private IFlightService _flightService;
        private ITripService _tripService;

        public HomeController()
        {
            _flightService = new FlightService();
            _tripService = new TripService();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewFlight()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewFlight(FlightViewModel model)
        {
            _flightService.AddNewFlight(model);
            return RedirectToAction("ViewFlights");
        }

        [HttpGet]
        public ActionResult ChangeFlight(string id)
        {
            FlightViewModel flightViewModel = _flightService.GetById(id);
            return View(flightViewModel);
        }

        [HttpPost]
        public ActionResult ChangeFlight(FlightViewModel flightViewModel)
        {
            _flightService.UpdateFlight(flightViewModel);
            return RedirectToAction("ViewFlights");
        }

        [HttpGet]
        public ViewResult ViewFlights()
        {
            List<FlightViewModel> flightViewModels = _flightService.GetAll();

            return View(flightViewModels.OrderBy(_ => _.Id));

            // Has to be ordered in database query scenarios for paging to work!
        }

        [HttpGet]
        public ViewResult ViewTrips()
        {
            List<TripViewModel> tripViewModels = _tripService.GetAll();

            return View(tripViewModels.OrderBy(_ => _.Id));

            // Has to be ordered in database query scenarios for paging to work!
        }

        [HttpPost]
        public ActionResult DeleteFlight(FlightViewModel model)
        {
            _flightService.RemoveFlight(model.Id);
            return RedirectToAction("ViewFlights");
        }


    }
}