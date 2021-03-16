import { Observable } from 'rxjs';
import { CalenderService } from './../../core/services/calender.service';
import { FilterService } from './../../core/services/filter.service';
import { ReservationService } from './../../core/services/reservation.service';
import { Component, OnInit, Input } from '@angular/core';
import { Reservation } from '../../shared/models/guest.model';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-restaurant-list',
  templateUrl: './restaurant-list.component.html',
  styleUrls: ['./restaurant-list.component.css']
})
export class RestaurantListComponent implements OnInit {
  @Input() columnsToDisplay: string[];

  reservations: Reservation[];
  dataSource = new MatTableDataSource();
  reservations2: Reservation[];

  constructor(
    private reservationService: ReservationService, 
    private filterService: FilterService, 
    private calenderService: CalenderService) { }

  ngOnInit(): void {
    // hate all these manual subscriptions - but hey, it's a hackathon! :D

    this.reservationService.getReservationsForToday()
      .subscribe(response => this.reservations = response);

    this.dataSource.data = this.reservations;

    this.filterService.filter.subscribe((filterValue) => {
      this.dataSource.filter = filterValue;
    })

    this.calenderService.dateSelected.subscribe((dateSelected) => {
      this.reservationService.getReservationsForDate(dateSelected)
      .subscribe(reservations => this.reservations2 = reservations);
    })

  }
}
