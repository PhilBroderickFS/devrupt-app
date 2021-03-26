import { GuestBookings } from './../../shared/models/guest.bookings.model';
import { Guest } from './../../shared/models/guest.model';
import { GuestBookingsService } from './../../core/services/guest-bookings.service';
import { Observable } from 'rxjs';
import { CalenderService } from './../../core/services/calender.service';
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

  guestBookings: GuestBookings;
  dataSource = new MatTableDataSource<Guest>();

  constructor(
    private reservationService: ReservationService, 
    private guestBookingsService: GuestBookingsService,
    private calenderService: CalenderService) { }

  ngOnInit(): void {
    // hate all these manual subscriptions - but hey, it's a hackathon! :D

    this.guestBookingsService.getReservationsForDate(new Date())
      .subscribe(res => this.dataSource.data = res.guests);

    this.calenderService.dateSelected.subscribe((dateSelected) => {
      this.guestBookingsService.getReservationsForDate(dateSelected)
      .subscribe(res => {
        this.dataSource.data = res.guests});
    })

  }
}
