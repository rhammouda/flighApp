using System;
using Xunit;
using FlightApp.Buseness;
using FlightApp.Model.Entities;
using FlightApp.Test.Mocks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FlightApp.Test
{
    public class FlightsManagerTest
    {
       

        [Fact]
        public void User_Should_Be_Able_To_Create_New_Flight()
        {
            Flight flight = new Flight();
            flight.departure =new Airport("Test Airport", 40, 5 );
            flight.destination = new Airport("Paris Orly airport", 48, 2);
            flight.airPlane = new Airplane("Boeing 730", 1, 800);
            IFlightsManager fightsManager = new FlightsManagerMock();
            fightsManager.createFligth(flight);
        }

        [Fact]
        public void User_Should_Be_Able_To_Retreive_Flights()
        {
            IFlightsManager fightsManager = new FlightsManagerMock();
            fightsManager.fetchAllFlights();
        }

        [Fact]
        public void User_Should_Be_Able_TO_Retreive_Fuel_Nedded_For_Flight()
        {
            Airport OrlyAirports = new Airport();
            OrlyAirports.name = "Paris Orly";
            OrlyAirports.gpsLat = 48.740294;
            OrlyAirports.gpsLong = 2.3854978;

            Airport TunisAirport = new Airport();
            TunisAirport.name = "Tunis Carthage";
            TunisAirport.gpsLat = 36.845533;
            TunisAirport.gpsLong = 10.2171057;

            Airplane boeing730 = new Airplane
            {
                name = "boeing  730",
                flightSpeedInKMH = 800,
                fuelConsommationInLiterByFlightSecond = 1.2
            };
            Flight flight = new Flight { departure = TunisAirport, destination = OrlyAirports, airPlane = boeing730 };

            Assert.True(flight.fuelNeededInLiter > 0);
        }

        [Fact]
        public void User_Should_Be_Able_To_Upadte_Flight()
        {
            IFlightsManager flightsManager = new FlightsManagerMock();
            var flightToUpdate = flightsManager.fetchAllFlights().FirstOrDefault();
            if (flightToUpdate == null) User_Should_Be_Able_To_Create_New_Flight();
            int id = flightsManager.fetchAllFlights().FirstOrDefault().Id;
            Flight flight = new Flight() ;

            var departure = new Airport
            {
                name = "Test airport",
                gpsLat = 40,
                gpsLong = 6
            };
            var destination = new Airport
            {
                name = "Test airport 2",
                gpsLat = 45,
                gpsLong = 10
            };
            var  airportsManager = new AirportsManagerMock();
            airportsManager.createAirport(departure);
            airportsManager.createAirport(destination);

            flight.departureId = departure.Id;
            flight.destinationId = destination.Id;

            flight.airPlane = new Airplane { name = "Boeing 350", flightSpeedInKMH = 500, fuelConsommationInLiterByFlightSecond = 0.5 };
            flightsManager.updateFlight(id, flight);

            Assert.Equal(destination.Id, flightsManager.fetchFlightById(id).destination.Id);
            Assert.Equal(departure.Id, flightsManager.fetchFlightById(id).departure.Id);
        }


        [Fact]
        public void findFligthById()
        {
            IFlightsManager flightsManager = new FlightsManagerMock();
            var flightToUpdate = flightsManager.fetchAllFlights().FirstOrDefault();
            if (flightToUpdate == null) User_Should_Be_Able_To_Create_New_Flight();
            int id = flightsManager.fetchAllFlights().FirstOrDefault().Id;
            flightsManager.fetchFlightById(id);
        }

    }
}
