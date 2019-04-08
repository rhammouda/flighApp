using FlightApp.Buseness.Buseness;
using FlightApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightApp.Test.Mocks
{
    public class AirportsManagerMock : AirportsManager
    {
        public AirportsManagerMock() : base(new AirportsRepositoryMock())
        {}
    }

    public class AirportsRepositoryMock: AirportsRepository
    {
        public AirportsRepositoryMock()
            :base(new ApplicationDbContextMock())
        {

        }
    }
}
