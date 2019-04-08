using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightApp.Buseness;
using FlightApp.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private IFlightsManager flightsManager; 
        public FlightsController(IFlightsManager flightsManager)
        {
            this.flightsManager = flightsManager;
        }
        // GET: api/Flights
        [HttpGet]
        public IEnumerable<Flight> Get()
        {
            return flightsManager.fetchAllFlights();
        }

        // GET: api/Flights/5
        [HttpGet("{id}", Name = "Get")]
        
        public Flight Get(int id)
        {
            return flightsManager.fetchFlightById(id);
        }

        // POST: api/Flights
        [HttpPost]
        public void Post(Flight flight)
        {
            flightsManager.createFligth(flight);
        }

        // PUT: api/Flights/5
        [HttpPut("{id}")]
        public void Put(int id, Flight flight)
        {
            flightsManager.updateFlight(id, flight);
        }
    }
}
