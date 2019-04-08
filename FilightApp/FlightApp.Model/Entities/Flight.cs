using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlightApp.Model.Entities
{
    public class Flight
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int departureId { get; set; }
        public int destinationId { get; set; }
        public int airplaneId { get; set; }
        [ForeignKey("departureId")]
        public Airport departure { get; set; }
        [ForeignKey("destinationId")]
        public Airport destination { get; set; }
        [ForeignKey("airplaneId")]
        public Airplane airPlane { get; set; }

        public int flightDurationInSecond => calculateFlightDurationInSecond();
        public double fuelNeededInLiter => calculateFuelNeeded();

        int calculateFlightDurationInSecond()
        {
            try
            {
                var distance = departure.calculateDistance(destination);
                return (int)((distance / airPlane.flightSpeedInKMH) * 3600);
            }catch
            {
                return 0;
            }
          
        }
        double calculateFuelNeeded()
        {
            return calculateFlightDurationInSecond() * airPlane?.fuelConsommationInLiterByFlightSecond ?? 0;
        }
    }
}
