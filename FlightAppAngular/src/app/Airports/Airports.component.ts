import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { AirportsService } from './airports.service';
import { Airport } from './Airport';

@Component({
  selector: 'app-airports',
  templateUrl: './Airports.component.html',
  styleUrls: ['./Airports.component.scss']
})
export class AirportsComponent implements OnInit, AfterViewInit {

  constructor(private airpotsService: AirportsService) { }

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource =  new MatTableDataSource<Airport>();

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['id', 'name'];

  ngOnInit(): void {
    this.airpotsService.getAllAirports().subscribe(airports => {
      this.dataSource.data = airports as Airport[];
    }, error => {

    });
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator =  this.paginator;
  }

}
