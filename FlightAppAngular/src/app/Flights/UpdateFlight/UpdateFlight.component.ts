import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormBuilder } from '@angular/forms';
import { Airplane } from 'src/app/Airplanes/Airplane';
import { Observable } from 'rxjs';
import { Airport } from 'src/app/Airports/Airport';
import { Router, ActivatedRoute } from '@angular/router';
import { FlightsService } from '../flights.service';
import { AlertService } from 'src/app/Global.service';
import { AirportsService } from 'src/app/Airports/airports.service';
import { AirplanesService } from 'src/app/Airplanes/Airplanes.service';
import { startWith, map } from 'rxjs/operators';
import { Flight } from '../Flight';

@Component({
  selector: 'app-update-flight',
  templateUrl: './UpdateFlight.component.html',
  styleUrls: ['./UpdateFlight.component.scss']
})
export class UpdateFlightComponent implements OnInit {

  private airplaneControl: FormControl = new FormControl('', Validators.required);
  private departureControl: FormControl = new FormControl('', Validators.required);
  private destinationControl: FormControl = new FormControl('', Validators.required);

  updateFlightForm = this.fb.group({
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
    private airplanesService: AirplanesService, private router: Router, private alertService: AlertService,
     private activeRoute: ActivatedRoute) {}

   private flight: Flight;
  async ngOnInit() {
    const id = this.activeRoute.snapshot.paramMap.get('id');
    this.airplanes = await this.airplanesService.getAllAirplanes().toPromise();
    this.airports = await this.airportsService.getAllAirports().toPromise();
    this.flightsService.getFlightByid(id).subscribe(flight => {
      this.flight = flight;
      this.airplaneControl.setValue(flight.airPlane);
      this.departureControl.setValue(flight.departure);
      this.destinationControl.setValue(flight.destination);
    }, e => {
      this.alertService.show('Error', 'Please verify that flight exitst and retry');
    });

    this.initAutocompleete();

  }

  save() {
    const flight = new Flight();
    if (this.updateFlightForm.valid) {
      flight.departureId = this.departureControl.value.id;
      flight.destinationId = this.destinationControl.value.id;
      flight.airplaneId = this.airplaneControl.value.id;
      flight.id = this.flight.id;
      this.flightsService.updateFlight(flight).subscribe(() => {
        this.router.navigate(['/flights']);
      }, e => {
        this.alertService.show('Error', 'An error has coccured, Please verify your connection and try again.');
      });

    }
  }

  private initAutocompleete() {
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
