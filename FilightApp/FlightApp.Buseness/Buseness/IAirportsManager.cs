using FlightApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightApp.Buseness.Buseness
{
    public interface IAirportsManager
    {
        void createAirport(Airport airport);
        ICollection<Airport> FetchAllAirports();
    }
}
