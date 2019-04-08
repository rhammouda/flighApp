using FlightApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightApp.Buseness
{
    public interface IFlightsManager
    {
        void createFligth(Flight  fight);
        Flight fetchFlightById(int id);
        ICollection<Flight> fetchAllFlights();
        void updateFlight(int id,Flight fight);
    }
}
