using System;
using System.Collections.Generic;
using System.Text;
using FlightApp.DAL.Repositories;
using FlightApp.Model.Entities;

namespace FlightApp.Buseness.Buseness
{
    public class FlightsManager : IFlightsManager
    {
        private IFlightsRepository flightsRepository;
        public FlightsManager(IFlightsRepository flightsRepository)
        {
            this.flightsRepository = flightsRepository;
        }

        public void createFligth(Flight flight)
        {
            flightsRepository.create(flight);
        }

        public ICollection<Flight> fetchAllFlights()
        {
            return flightsRepository.fetchAll();
        }

        public Flight fetchFlightById(int id)
        {
            return flightsRepository.fetchById(id);
        }

        public void updateFlight(int id, Flight flight)
        {
            Flight oldFlight = flightsRepository.fetchById(id);
            oldFlight.airplaneId = flight.airplaneId;
            oldFlight.departureId = flight.departureId;
            oldFlight.destinationId = flight.destinationId;
            flightsRepository.update(oldFlight);
        }
    }
}
