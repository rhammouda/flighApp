using FlightApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightApp.Buseness.Buseness
{
    public interface IAirplanesManager
    {
        void createAirplane(Airplane airplane);
        ICollection<Airplane> fetchAllAirplanes();
    }
}
