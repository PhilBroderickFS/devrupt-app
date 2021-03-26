import { GuestBookings } from './../../shared/models/guest.bookings.model';
import { GuestBookingsService } from './../../core/services/guest-bookings.service';
import { CalenderService } from './../../core/services/calender.service';
import { Day } from './../../shared/models/day.model';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Observable, forkJoin } from 'rxjs';

@Component({
  selector: 'app-calender-slider',
  templateUrl: './calender-slider.component.html',
  styleUrls: ['./calender-slider.component.css']
})
export class CalenderSliderComponent implements OnInit {

  selectedDayIndex: number = 0;
  days$: Observable<Day[]> = this.calenderService.getNextNDays(11);
  bookings$: Observable<GuestBookings[]> = this.guestBookingService.getNextNDayBookings(11);
  constructor(private calenderService : CalenderService, private guestBookingService: GuestBookingsService) { }

  ngOnInit(): void {
  }

  onDaySelected(index: number) {

    this.selectedDayIndex = index;
    
    // quick way to get the date for a selected day as they are 2 separate observables

    forkJoin([this.days$, this.bookings$]).subscribe(results => {
      let day = results[0][index];
      this.calenderService.dateSelected.next(day.date);
    })
  }

  isSelectedDay(index: number) {
    return index == this.selectedDayIndex;
  }

}
