using System;
using System.Collections.Generic;
using System.Text;
using FlightApp.DAL.Repositories;
using FlightApp.Model.Entities;

namespace FlightApp.Buseness.Buseness
{
    public class AirplanesManager : IAirplanesManager
    {
        private IAirplanesRepository airplaneRepository;

        public AirplanesManager(IAirplanesRepository airplaneRepository)
        {
            this.airplaneRepository = airplaneRepository;
        }
        public void createAirplane(Airplane airplane)
        {
            airplaneRepository.create(airplane);
        }

        public ICollection<Airplane> fetchAllAirplanes()
        {
            return airplaneRepository.fetchAll();
        }
    }
}
