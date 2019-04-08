import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AirplanesService } from '../Airplanes.service';
import { Airplane } from '../Airplane';
import { AlertService } from 'src/app/Global.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-airplane',
  templateUrl: './createAirplane.component.html',
  styleUrls: ['./createAirplane.component.scss']
})
export class CreateAirplaneComponent {

  formAirplane = this.fb.group({
    name: null,
    fuelConsommationInLiterByFlightSecond: [null, Validators.required],
    flightSpeedInKMH: [null, Validators.required],
  });

  constructor(private fb: FormBuilder, private airplaneService: AirplanesService, private alertService: AlertService,
    private router: Router) {}

  onSubmit() {
    if (this.formAirplane.valid) {
      const airplane = new Airplane();
      airplane.name = this.formAirplane.controls.name.value;
      airplane.fuelConsommationInLiterByFlightSecond = this.formAirplane.controls.fuelConsommationInLiterByFlightSecond.value;
      airplane.flightSpeedInKMH = this.formAirplane.controls.flightSpeedInKMH.value;
      this.airplaneService.saveAirplane(airplane).subscribe(() => {
        this.router.navigate(['/airplanes']);
      }, error => {
        this.alertService.show('Error', 'An error has occured, please verify your connection and try again');
      });
    }
  }
}
