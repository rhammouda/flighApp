using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlightApp.Model.Entities;

namespace FlightApp.DAL.Repositories
{
    public class AirplanesRepository : IAirplanesRepository
    {
        protected ApplicationDbContext context;

        public AirplanesRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void create(Airplane airplane)
        {
            context.airplanes.Add(airplane);
            context.SaveChanges();
        }

        public ICollection<Airplane> fetchAll()
        {
            return context.airplanes.ToList();
        }
    }
}
