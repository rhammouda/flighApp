using FlightApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightApp.DAL.Repositories
{
    public interface IAirplanesRepository
    {
        void create(Airplane airplane);
        ICollection<Airplane> fetchAll();
    }
}
