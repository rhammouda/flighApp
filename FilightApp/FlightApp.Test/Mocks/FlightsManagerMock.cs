using FlightApp.Buseness;
using FlightApp.Buseness.Buseness;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightApp.Test.Mocks
{
    public class FlightsManagerMock : FlightsManager
    {
        public FlightsManagerMock():
            base(new FlightsRepositoryMock())
        {
        }
    }
}
