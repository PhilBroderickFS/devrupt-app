import { Injectable } from '@angular/core';
import { Reservation } from 'src/app/shared/models/guest.model';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {
  reservations: Reservation[] = [];
  constructor() { }

  getReservationsForToday = () : Reservation[] => {
    let res = new Reservation('1', 'Phil Broderick', '1', new Date(), new Date());

    this.reservations.push(res);

    return this.reservations;
  }
}
