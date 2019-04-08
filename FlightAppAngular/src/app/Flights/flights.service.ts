import { Injectable } from '@angular/core';
import { GlobalService } from '../Global.service';
import { Flight } from './Flight';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class FlightsService {

  constructor(private global: GlobalService,  private http: HttpClient) { }

  getAllFlights(): Observable<Flight[]> {
    return this.http.get<Flight[]>(this.global.urlApi + '/flights');
  }

  saveFlight(flight: Flight): Observable<any> {
    return this.http.post(this.global.urlApi + '/flights', flight);
  }

  getFlightByid(id): Observable<Flight> {
    return this.http.get<Flight>(this.global.urlApi + '/flights/' + id);
  }

  updateFlight(flight: Flight): Observable<any> {
    return this.http.put (this.global.urlApi + '/flights/' + flight.id, flight);
  }

}
