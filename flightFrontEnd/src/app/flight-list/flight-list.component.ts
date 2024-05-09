import { Component, OnInit } from '@angular/core';
import { FlightService } from '../services/flight.service';
import { JourneyInterface } from '../interfaces/journey-interface';
import { FlightInterface } from '../interfaces/flight-interface';

@Component({
  selector: 'app-flight-list',
  templateUrl: './flight-list.component.html',
  styleUrls: ['./flight-list.component.scss']
})
export class FlightListComponent implements OnInit {
  journeys: JourneyInterface[] = [];
  allFlights: FlightInterface[] = [];
  origins: string[] = [];
  destinations: string[] = [];
  currencies: string[] = ['USD', 'EUR', 'GBP', 'COP', 'ARS', 'BRL', 'MXN', 'CLP', 'PEN', 'UYU', 'VEF'];
  origin = '';
  destination = '';
  currency = '';
  type = '';
  displayFlights: boolean = false;
  displayJourneys: boolean = false;

  constructor(private flightService: FlightService) { }

  ngOnInit(): void {
    this.getAllFlights();
  }

  getAllFlights(): void {
    this.flightService.getAllFlights().subscribe(data => {
      this.allFlights = data;
      this.origins = [...new Set(data.map(flight => flight.origin))];
      this.destinations = [...new Set(data.map(flight => flight.destination))];

    }, error => {
      console.error('Error:', error);
    });
  }

  displayAllFlights(): void {
    this.getAllFlights();
    this.displayFlights = true;
    this.displayJourneys = false;

  }

  getFlights() {
    this.flightService.getFlights(this.origin, this.destination, this.currency, this.type).subscribe(data => {
      if (data) {
        if (Array.isArray(data)) {
          this.journeys = data;
        } else {
          this.journeys = Object.keys(data).map(key => data[key]);
        }
        if (this.journeys[0] && this.journeys[0].flights[0]) {
          console.log(this.journeys[0].flights[0]);
        } else {
          console.log('journeys[0] or journeys[0].flights[0] is undefined');
        }
      } else {
        console.log('data is undefined');
      }

    }, error => {
      console.error('Error:', error);
    });
  }

  displaySearchedFlights(): void {
    this.flightService.getFlights(this.origin, this.destination, this.currency, this.type).subscribe(flights => {
      if (Array.isArray(flights)) {
        this.journeys = flights;
      } else {
        this.journeys = Object.keys(flights).map(key => flights[key]);
      }
      this.displayJourneys = true;

    });
    this.getFlights();
    this.displayFlights = false;
  }
}