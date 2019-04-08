using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlightApp.Model.Entities
{
    public class Airport
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string name { get; set; }
        public double gpsLat { get; set; }
        public double gpsLong { get; set; }

        public Airport(string name, double gpsLat, double gpsLong)
        {
            this.name = name;
            this.gpsLat = gpsLat;
            this.gpsLong = gpsLong;
        }
        public Airport()
        {

        }
        public double calculateDistance(Airport airport)
        {
            return distanceInKmBetweenEarthCoordinates(gpsLat, gpsLong, airport.gpsLat, airport.gpsLong);
        }

        double distanceInKmBetweenEarthCoordinates(double lat1, double lon1, double lat2, double lon2)
        {
            var earthRadiusKm = 6371;

            var dLat = degreesToRadians(lat2 - lat1);
            var dLon = degreesToRadians(lon2 - lon1);

            lat1 = degreesToRadians(lat1);
            lat2 = degreesToRadians(lat2);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return earthRadiusKm * c;
        }

        double degreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }

    }
}
