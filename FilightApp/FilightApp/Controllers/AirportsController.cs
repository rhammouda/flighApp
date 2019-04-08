using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightApp.Buseness.Buseness;
using FlightApp.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private IAirportsManager airportsManager;

        public AirportsController(IAirportsManager airportsManager)
        {
            this.airportsManager = airportsManager;
        }

        // GET: api/Airports
        [HttpGet]
        public IEnumerable<Airport> Get()
        {
            return airportsManager.FetchAllAirports();
        }

        // POST: api/Airports
        [HttpPost]
        public void Post(Airport airport)
        {
            airportsManager.createAirport(airport);
        }
    }
}
