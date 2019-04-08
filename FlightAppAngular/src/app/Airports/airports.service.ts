import { Injectable } from '@angular/core';
import { GlobalService } from '../Global.service';
import { Airport } from './Airport';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AirportsService {

  constructor(private global: GlobalService,  private http: HttpClient) { }

  getAllAirports(): Observable<Airport[]> {
    return this.http.get<Airport[]>(this.global.urlApi + '/Airports');
  }

  saveAirport(airplane: Airport): Observable<any> {
    return this.http.post(this.global.urlApi + '/Airports', airplane);
  }

}
