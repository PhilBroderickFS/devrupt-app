import { GuestBookings } from './../../shared/models/guest.bookings.model';
import { Injectable } from '@angular/core';
import { Observable, from, of } from 'rxjs';
import { tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Reservation } from '../../shared/models/guest.model';

@Injectable({
  providedIn: 'root'
})
export class GuestBookingsService {
  private reservationsUrl = 'https://localhost:5001/api/reservation';

  guestBookings: GuestBookings[] = [];
  constructor(private httpClient: HttpClient) { }

  getNextNDayBookings(numOfDays: number): Observable<GuestBookings[]> {

    return this.httpClient.get<GuestBookings[]>(`${this.reservationsUrl}/${numOfDays}`);
  }

  getReservationsForDate(date: Date): Observable<GuestBookings> {
    let day = date.getDate();
    let month = date.getMonth() + 1;
    let year = date.getFullYear();
    let formattedDate = `${day}-${month}-${year}`;
    const params = {
      'dateStr' : formattedDate
    };

    return this.httpClient.get<GuestBookings>(`${this.reservationsUrl}/date`, { params: params });
  }
}
