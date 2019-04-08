using FlightApp.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightApp.Test.Mocks
{
    public class FlightsRepositoryMock : FlightsRepository
    {
        public FlightsRepositoryMock()
            :base(new ApplicationDbContextMock())
        {
            
        }
    }
}
