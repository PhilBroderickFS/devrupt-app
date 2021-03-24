import { Injectable } from '@angular/core';
import { Reservation } from 'src/app/shared/models/guest.model';
import { Observable, from, of } from 'rxjs';
import { tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {
  private reservationsUrl = 'api/reservations';

  reservations: Reservation[] = [];
  constructor(private httpClient: HttpClient) { }

  getReservationsForToday() : Observable<Reservation[]> {
    return this.httpClient.get<Reservation[]>(this.reservationsUrl);
  }

  getNextNDayReservationNos(numOfDays: number): Observable<number[]> {
    // TODO retrieve from API 
    return of([1,2,3,4,5,6,7,32,1,10,11]);
  }

  getReservationsForDate(date: Date): Observable<Reservation[]> {
    let day = date.getDate();
    let month = date.getMonth() + 1;
    let year = date.getFullYear();
    let formattedDate = `${day}-${month}-${year}`;
    const params = {
      'arrival' : formattedDate
    };

    return this.httpClient.get<Reservation[]>(`${this.reservationsUrl}`, { params: params });
  }
}
