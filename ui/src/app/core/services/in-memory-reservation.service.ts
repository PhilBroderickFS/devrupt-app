import { Injectable } from '@angular/core';
import { InMemoryDbService } from 'angular-in-memory-web-api';
import { Reservation } from 'src/app/shared/models/guest.model';

@Injectable({
  providedIn: 'root'
})
export class InMemoryReservationService implements InMemoryDbService {

  createDb() {
    const reservations = [];
    let res = new Reservation('1', 'Phil Broderick', '1', new Date(), new Date());
    reservations.push(res);
    return {reservations};
  }
}
