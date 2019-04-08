using System;
using System.Collections.Generic;
using System.Text;
using FlightApp.DAL.Repositories;
using FlightApp.Model.Entities;

namespace FlightApp.Buseness.Buseness
{
    public class AirportsManager : IAirportsManager
    {
        private IAirportsRepository airportsRepository;

        public AirportsManager(IAirportsRepository airportsRepository)
        {
            this.airportsRepository = airportsRepository;
        }

        public void createAirport(Airport airport)
        {
            airportsRepository.create(airport);
        }

        public ICollection<Airport> FetchAllAirports()
        {
            return airportsRepository.fetchAll();
        }

    
       

       
    }
}
