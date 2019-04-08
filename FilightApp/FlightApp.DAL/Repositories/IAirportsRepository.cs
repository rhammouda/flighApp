using FlightApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightApp.DAL.Repositories
{
    public interface IAirportsRepository
    {
        ICollection<Airport> fetchAll();
        void create(Airport airport);
    }
}
