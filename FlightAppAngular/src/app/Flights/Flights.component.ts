import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { FlightsService } from './flights.service';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { Flight } from './Flight';

@Component({
  selector: 'app-flights',
  templateUrl: './Flights.component.html',
  styleUrls: ['./Flights.component.scss']
})
export class FlightsComponent implements OnInit , AfterViewInit {

  constructor(private flightsServive: FlightsService) { }

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource =  new MatTableDataSource<FlightViemodel>();

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['id', 'departure', 'destination', 'airplane', 'fuelNeededInLiter', 'flightDurationInSecond', 'action'];

  ngOnInit(): void {
    this.flightsServive.getAllFlights().subscribe(airports => {
      this.dataSource.data = airports.map(flight => {
        return {
          departure: flight.departure ? flight.departure.name : '-',
          destination: flight.destination ? flight.destination.name : '-',
          airplane: flight.airPlane ? flight.airPlane.name : '-',
          id: flight.id,
          fuelNeededInLiter: flight.flightDurationInSecond,
          flightDurationInSecond: flight.flightDurationInSecond
        } as FlightViemodel;
      });
    }, error => {

    });
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator =  this.paginator;
  }

}

class FlightViemodel {
  id: number;
  departure: string;
  destination: string;
  airplane: string;
  fuelNeededInLiter: number;
  flightDurationInSecond: number;
}
