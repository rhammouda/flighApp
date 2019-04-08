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
    public class AirplanesController : ControllerBase
    {
        private IAirplanesManager airplanesManager;

        public AirplanesController(IAirplanesManager airplanesManager)
        {
            this.airplanesManager = airplanesManager;
        }

        // GET: api/Airplanes
        [HttpGet]
        public IEnumerable<Airplane> Get()
        {
            return airplanesManager.fetchAllAirplanes();
        }


        // POST: api/Airplanes
        [HttpPost]
        public void Post([FromBody] Airplane airplane)
        {
            airplanesManager.createAirplane(airplane);
        }
    }
}
