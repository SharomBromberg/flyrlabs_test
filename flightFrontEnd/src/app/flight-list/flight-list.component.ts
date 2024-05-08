import { Component, OnInit } from '@angular/core';
import { FlightInterface } from '../interfaces/flight-interface';
import { FlightService } from '../services/flight.service';
import { JourneyInterface } from '../interfaces/journey-interface';
@Component({
  selector: 'app-flight-list',
  templateUrl: './flight-list.component.html',
  styleUrls: ['./flight-list.component.scss']
})
export class FlightListComponent implements OnInit {
  journeys: JourneyInterface[] = [];
  origin = '';
  destination = '';
  currency = '';
  type = '';

  constructor(private flightService: FlightService) { }

  ngOnInit(): void {

  }
  searchFlights(): void {
    this.flightService.getFlights(this.origin, this.destination, this.currency, this.type).subscribe(data => {
      this.journeys = [data];
      console.log(this.journeys);
    }, error => {
      console.error('Error:', error);
    });
  }
}
