using FlightApp.Buseness.Buseness;
using FlightApp.Model.Entities;
using FlightApp.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FlightApp.Test
{
    public class AirportManagerTest
    {
        [Fact]
        public void create_Airport()
        {
            Airport airport = new Airport();
            airport.name = "Paris Orly";
            airport.gpsLat = 48.740294;
            airport.gpsLong = 2.3854978;
            IAirportsManager airportsManager = new AirportsManagerMock();
            airportsManager.createAirport(airport);

        }

        [Fact]
        public void fetch_Airport()
        {
            IAirportsManager airportsManager = new AirportsManagerMock();
            airportsManager.FetchAllAirports();
        }

        [Fact]
        public void DistanceBetweenTwoAirports()
        {
            Airport OrlyAirports = new Airport();
            OrlyAirports.name = "Paris Orly";
            OrlyAirports.gpsLat = 48.740294;
            OrlyAirports.gpsLong = 2.3854978;

            Airport TunisAirport = new Airport();
            TunisAirport.name = "Tunis Carthage";
            TunisAirport.gpsLat = 36.845533;
            TunisAirport.gpsLong = 10.2171057;
            double distance = OrlyAirports.calculateDistance(TunisAirport);
            Assert.True(Math.Abs(1470 - (int)distance) < 5);
        }
    }
}
