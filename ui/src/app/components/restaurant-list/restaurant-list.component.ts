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
  columnsToDisplay = ['ref', 'name', 'room', 'arrival', 'departure', 'actions'];
  reservations: Reservation[];
  dataSource = new MatTableDataSource(this.reservations);

  constructor(private reservationService: ReservationService, private filterService: FilterService) { }

  ngOnInit(): void {
    this.reservations = this.reservationService.getReservationsForToday();
    this.dataSource.data = this.reservations;

    this.filterService.filter.subscribe((filterValue) => {
      this.dataSource.filter = filterValue;
    })
  }
}
