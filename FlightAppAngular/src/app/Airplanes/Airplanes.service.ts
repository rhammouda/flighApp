import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GlobalService } from '../Global.service';
import { Observable } from 'rxjs';
import { Airplane } from './Airplane';

@Injectable({
  providedIn: 'root'
})
export class AirplanesService {

constructor(private http: HttpClient, private global: GlobalService) { }

  getAllAirplanes(): Observable<Airplane[]> {
    return this.http.get<Airplane[]>(this.global.urlApi + '/Airplanes');
  }

  saveAirplane(airplane: Airplane): Observable<any> {
    return this.http.post(this.global.urlApi + '/Airplanes', airplane);
  }

}
