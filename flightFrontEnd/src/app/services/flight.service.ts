import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environment/environment';
import { FlightInterface } from '../interfaces/flight-interface';
import { JourneyInterface } from '../interfaces/journey-interface';

@Injectable({
  providedIn: 'root'
})
export class FlightService {
  private apiUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getAllFlights(): Observable<FlightInterface[]> {
    return this.http.get<FlightInterface[]>(`${this.apiUrl}/Flight/AllFlights`);
  }

  getOneWayFlights(origin: string, destination: string, currency: string): Observable<JourneyInterface> {
    return this.http.get<JourneyInterface>(`${this.apiUrl}/Flight/Flights?origin=${origin}&destination=${destination}&currency=${currency}&flightType=oneway`);
  }

  getRoundTripFlights(origin: string, destination: string, currency: string): Observable<JourneyInterface> {
    return this.http.get<JourneyInterface>(`${this.apiUrl}/Flight/Flights?origin=${origin}&destination=${destination}&currency=${currency}&flightType=roundtrip`);
  }
  getFlights(origin: string, destination: string, currency: string, flightType: string): Observable<JourneyInterface[]> {
    return this.http.get<JourneyInterface[]>(`${this.apiUrl}/Flight/Flights?origin=${origin}&destination=${destination}&currency=${currency}&flightType=${flightType}`);
  }
} 