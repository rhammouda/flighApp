using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlightApp.Model.Entities
{
    public class Airplane
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string name { get; set; }
        public double fuelConsommationInLiterByFlightSecond { get; set; }
        public double flightSpeedInKMH { get; set; }

        public Airplane(string name,double  fuelConsommationInLiterByFlightSecond, double flightSpeedInKMH)
        {
            this.name = name;
            this.fuelConsommationInLiterByFlightSecond = fuelConsommationInLiterByFlightSecond;
            this.flightSpeedInKMH = flightSpeedInKMH;
        }

        public Airplane() { }
    }
}

