using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlightApp.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlightApp.DAL.Repositories
{
    public class FlightsRepository : IFlightsRepository
    {
        protected ApplicationDbContext context;
        public FlightsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void create(Flight flight)
        {
            context.flights.Add(flight);
            context.SaveChanges();
        }

        public Flight fetchById(int id)
        {
            return context.flights.Include(f => f.airPlane).Include(f => f.departure).Include(f => f.destination)
                .FirstOrDefault(f => f.Id == id);
        }

        public IList<Flight> fetchAll()
        {
            return context.flights.Include(f=>f.airPlane).Include(f=>f.departure).Include(f => f.destination).ToList();
        }

        public void update(Flight flight)
        {
            context.Entry(flight).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
