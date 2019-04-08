using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlightApp.Model.Entities;

namespace FlightApp.DAL.Repositories
{
    public class AirportsRepository : IAirportsRepository
    {
        private ApplicationDbContext context;

        public AirportsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void create(Airport airport)
        {
            context.airports.Add(airport);
            context.SaveChanges();
        }

        public ICollection<Airport> fetchAll()
        {
            return context.airports.ToList();
        }
    }
}
