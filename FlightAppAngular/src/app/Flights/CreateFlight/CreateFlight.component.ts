import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, Validators, FormControl, FormGroup } from '@angular/forms';
import { Flight } from '../Flight';
import { FlightsService } from '../flights.service';
import { AirportsService } from 'src/app/Airports/airports.service';
import { Airplane } from 'src/app/Airplanes/Airplane';
import { Airport } from 'src/app/Airports/Airport';
import { AirplanesService } from 'src/app/Airplanes/Airplanes.service';
import { startWith, map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { AlertService, AlertMessageDialogComponent } from 'src/app/Global.service';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-create-flight',
  templateUrl: './CreateFlight.component.html',
  styleUrls: ['./CreateFlight.component.scss']
})
export class CreateFlightComponent implements OnInit {

  private airplaneControl: FormControl = new FormControl('', Validators.required);
  private departureControl: FormControl = new FormControl('', Validators.required);
  private destinationControl: FormControl = new FormControl('', Validators.required);

  createFilghtForm = this.fb.group({
    airplane: this.airplaneControl,
    departure: this.departureControl,
    destination: this.destinationControl,
  });
  hasUnitNumber = false;

  private airplanes: Airplane[];
  private airports: Airport[];

  filteredAirplanes: Observable<Airplane[]>;
  filteredDestinations: Observable<Airport[]>;
  filteredDepartures: Observable<Airport[]>;

  constructor(private fb: FormBuilder, private flightsService: FlightsService, private airportsService: AirportsService,
    private airplanesService: AirplanesService, private router: Router, private alertService: AlertService, public dialog: MatDialog) {}

  async ngOnInit() {
    this.airplanes = await this.airplanesService.getAllAirplanes().toPromise();
    this.airports = await this.airportsService.getAllAirports().toPromise();
    this.initAutoCompleete();
  }

  save() {
    if (this.createFilghtForm.valid) {
      const flight = new Flight();
      flight.departureId = this.departureControl.value.id;
      flight.destinationId = this.destinationControl.value.id;
      flight.airplaneId = this.airplaneControl.value.id;
      this.flightsService.saveFlight(flight).subscribe(() => {
        this.router.navigate(['/flights']);
      }, e => {
        this.alertService.show('Error', 'An error has coccured, Please verify your connection and try again.');
      });

    }
  }

  // Autocompleete select
  private initAutoCompleete() {
    this.filteredAirplanes = this.airplaneControl.valueChanges
      .pipe(
        startWith<string | Airplane>(''),
        map(value => typeof value === 'string' ? value : value.name),
        map(name => name ? this._filter(this.airplanes, name) as Airplane[] : this.airplanes.slice())
      );

      this.filteredDepartures = this.departureControl.valueChanges
      .pipe(
        startWith<string | Airport>(''),
        map(value => typeof value === 'string' ? value : value.name),
        map(name => name ? this._filter(this.airports, name) as Airport[] : this.airports.slice())
      );

      this.filteredDestinations = this.destinationControl.valueChanges
      .pipe(
        startWith<string | Airport>(''),
        map(value => typeof value === 'string' ? value : value.name),
        map(name => name ? this._filter(this.airports, name) as Airport[] : this.airports.slice())
      );
  }
  private _filter(array: any[] , name: string): any[] {
    const filterValue = name.toLowerCase();
    return array.filter(option => option.name.toLowerCase().indexOf(filterValue) === 0);
  }
  displayFn(user?: any): string | undefined {
    return user ? user.name : undefined;
  }
}
