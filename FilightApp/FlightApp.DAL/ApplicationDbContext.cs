using System;
using System.Collections.Generic;
using System.Text;
using FlightApp.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlightApp.DAL
{
    public class ApplicationDbContext: DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public ApplicationDbContext() { }

    public virtual DbSet<Flight> flights { get; set; }
    public virtual DbSet<Airport> airports { get; set; }
    public virtual DbSet<Airplane> airplanes { get; set; }
    }
}
