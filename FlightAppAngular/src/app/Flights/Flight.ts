import { Airport } from '../Airports/Airport';
import { Airplane } from '../Airplanes/Airplane';

export class Flight {
    id: number;
    departure: Airport;
    destination: Airport;
    airPlane: Airplane;
    departureId: number;
    destinationId: number;
    airplaneId: number;
    flightDurationInSecond: number;
    fuelNeededInLiter: number;
}
