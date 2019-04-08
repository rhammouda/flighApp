using FlightApp.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FlightApp.Test.Mocks
{
    public class ApplicationDbContextMock: ApplicationDbContext
    {
        public ApplicationDbContextMock():base()
        {
           
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server =.; Database =FlightsBD; Trusted_Connection = True; MultipleActiveResultSets = true");
           
        }
    }
}
