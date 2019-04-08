import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FlightsComponent } from './Flights/Flights.component';
import { UpdateFlightComponent } from './Flights/UpdateFlight/UpdateFlight.component';
import { CreateFlightComponent } from './Flights/CreateFlight/CreateFlight.component';
import { AirportsComponent } from './Airports/Airports.component';
import { PageNotFoundComponent } from './PageNotFoundComponent/PageNotFoundComponent.component';
import { DashbordComponent } from './dashbord/dashbord.component';
import { AirplanesComponent } from './Airplanes/Airplanes.component';
import { CreateAirportComponent } from './Airports/createAirport/createAirport.component';
import { CreateAirplaneComponent } from './Airplanes/createAirplane/createAirplane.component';

const routes: Routes = [
{ path: 'flights', component: FlightsComponent ,   data: { title: 'Flights List' }},
{ path: 'flights/add', component: CreateFlightComponent },
{ path: 'flights/update/:id', component: UpdateFlightComponent },
{ path: 'airports', component: AirportsComponent},
{ path: 'airports/add', component: CreateAirportComponent },
{ path: 'airplanes', component: AirplanesComponent},
{ path: 'airplanes/add', component: CreateAirplaneComponent },
{ path: 'dashboard', component: DashbordComponent},
{ path: '', redirectTo: '/flights', pathMatch: 'full'},
{ path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
