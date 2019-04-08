import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MainNavComponent } from './main-nav/main-nav.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule, MatButtonModule, MatSidenavModule, MatIconModule,
   MatListModule, MatGridListModule, MatCardModule, MatMenuModule, MatTableModule,
   MatPaginatorModule, MatSortModule , MatInputModule,
   MatSelectModule, MatRadioModule , MatAutocompleteModule, MatDialogModule} from '@angular/material';

import { CreateFlightComponent } from './Flights/CreateFlight/CreateFlight.component';
import { UpdateFlightComponent } from './Flights/UpdateFlight/UpdateFlight.component';
import { PageNotFoundComponent } from './PageNotFoundComponent/PageNotFoundComponent.component';
import { AirportsComponent } from './Airports/Airports.component';
import { AirplanesComponent } from './Airplanes/Airplanes.component';
import { FlightsComponent } from './Flights/Flights.component';
import { DashbordComponent } from './dashbord/dashbord.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { AlertMessageDialogComponent } from './Global.service';
import { CreateAirplaneComponent } from './Airplanes/createAirplane/createAirplane.component';
import { CreateAirportComponent } from './Airports/createAirport/createAirport.component';

@NgModule({
  declarations: [
    AppComponent,
    FlightsComponent,
      AirplanesComponent,
      AirportsComponent,
      PageNotFoundComponent,
      UpdateFlightComponent,
      CreateFlightComponent,
    MainNavComponent,
    DashbordComponent,
    AlertMessageDialogComponent,
    CreateAirplaneComponent,
    CreateAirportComponent
  ],
  entryComponents: [AlertMessageDialogComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatGridListModule,
    MatCardModule,
    MatMenuModule,
    HttpClientModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatButtonModule,
    MatInputModule,
    MatSelectModule,
    MatRadioModule,
    ReactiveFormsModule,
    MatAutocompleteModule,
    MatDialogModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
