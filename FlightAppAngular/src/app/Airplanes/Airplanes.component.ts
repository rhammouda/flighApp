import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { AirplanesService } from './Airplanes.service';
import { Airplane } from './Airplane';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';

@Component({
  selector: 'app-airplanes',
  templateUrl: './Airplanes.component.html',
  styleUrls: ['./Airplanes.component.scss']
})
export class AirplanesComponent implements OnInit, AfterViewInit {

  airplanes: Airplane[];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource =  new MatTableDataSource<Airplane>();

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['id', 'name', 'fuelConsommationInLiterByFlightSecond', 'flightSpeedInKMH'];

  constructor(private airplanesService: AirplanesService) { }


  ngOnInit() {
    this.airplanesService.getAllAirplanes().subscribe(data => {
      this.dataSource.data  = data;
    }, error => {
    });
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator =  this.paginator;
  }


}
