using FlightApp.Buseness.Buseness;
using FlightApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightApp.Test.Mocks
{
    class AirplanesManagerMock: AirplanesManager
    {
        public AirplanesManagerMock()
            : base(new AirplanesRepositoryMock())
        {

        }
    }

    public class AirplanesRepositoryMock: AirplanesRepository
    {
        public AirplanesRepositoryMock()
            :base(new ApplicationDbContextMock())
        {

        }
    }
}
