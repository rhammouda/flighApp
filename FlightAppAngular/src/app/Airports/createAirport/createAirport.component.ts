import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AirportsService } from '../airports.service';
import { AlertService } from 'src/app/Global.service';
import { Airport } from '../Airport';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-create-airport',
  templateUrl: './createAirport.component.html',
  styleUrls: ['./createAirport.component.scss']
})
export class CreateAirportComponent  {

  formAirport = this.fb.group({
    name: null,
    gpsLat: [null, Validators.required],
    gpsLong: [null, Validators.required],
  });

  constructor(private fb: FormBuilder, private airportsService: AirportsService, private alertService: AlertService,
    private router: Router) {}

  onSubmit() {
    if (this.formAirport.valid) {
      const airport = new Airport();
      airport.name = this.formAirport.controls.name.value;
      airport.gpsLat = this.formAirport.controls.gpsLat.value;
      airport.gpsLong = this.formAirport.controls.gpsLong.value;
      this.airportsService.saveAirport(airport).subscribe(() => {
        this.router.navigate(['/airports']);
      }, error => {
        this.alertService.show('Error', 'An error has occured, please verify your connection and try again');
      });
    }
  }
}
