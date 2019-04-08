using FlightApp.Buseness.Buseness;
using FlightApp.Model.Entities;
using FlightApp.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FlightApp.Test
{
    public class AirplanesManagerTest
    {
        [Fact]
        public void create_airplane()
        {
            Airplane airlane = new Airplane();
            airlane.name = "Boing 730";
            airlane.flightSpeedInKMH = 800;
            airlane.fuelConsommationInLiterByFlightSecond = 1;
            IAirplanesManager airplanesManager = new AirplanesManagerMock();
            airplanesManager.createAirplane(airlane);
        }

        [Fact]
        public void fetch_airplanes()
        {
            IAirplanesManager airplanesManager = new AirplanesManagerMock();
            airplanesManager.fetchAllAirplanes();
        }
    }
}
