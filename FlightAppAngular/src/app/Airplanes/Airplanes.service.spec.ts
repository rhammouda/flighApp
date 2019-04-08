/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AirplanesService } from './Airplanes.service';
import { Airplane } from './Airplane';

describe('Service: Airplanes', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AirplanesService]
    });
  });

  it('should ...', inject([AirplanesService], (service: AirplanesService) => {
    expect(service).toBeTruthy();
    service.getAllAirplanes().subscribe(airplanes => {
      expect(airplanes).toBeTruthy();
    }, eror => {
      fail('Cannot get airplanes');
    });

    const airplane = new Airplane();
    airplane.flightSpeedInKMH = 500;
    airplane.fuelConsommationInLiterByFlightSecond = .8;
    airplane.name = 'Airbus 720';
    service.saveAirplane(airplane).subscribe(data => {
    }, error => {
      fail('Cannot save airplane');
    });
  }));
});
