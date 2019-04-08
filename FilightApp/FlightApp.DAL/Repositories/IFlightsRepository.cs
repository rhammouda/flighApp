using FlightApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightApp.DAL.Repositories
{
    public interface IFlightsRepository
    {
        IList<Flight> fetchAll();
        Flight fetchById(int id);
        void create(Flight  flight);
        void update(Flight  flight);
    }
}
