import { Injectable } from '@angular/core';
import { InMemoryDbService, RequestInfo, ResponseOptions, STATUS, getStatusText } from 'angular-in-memory-web-api';
import { Reservation } from 'src/app/shared/models/guest.model';
import { filter } from 'rxjs/operators';

const reservations: Reservation[] = [
  {
    guacID:'D34GF3',
    reservationNo:'1',
    guestName: 'Phil Broderick',
    roomNo: '1', 
    arrival: new Date("2021-03-23"), 
    departure: new Date("2021-03-29")
  },
  {
    guacID:'D34GF5',
    reservationNo:'1',
    guestName: 'Philip Broderick',
    roomNo: '1', 
    arrival: new Date("2021-03-26"), 
    departure: new Date("2021-03-27")
  },
  {
    guacID:'D34GF4',
    reservationNo:'1',
    guestName: 'Philo Broderick',
    roomNo: '1', 
    arrival: new Date("2021-04-01"), 
    departure: new Date("2021-04-02")
  },
  {
    guacID:'D34GF1',
    reservationNo:'1',
    guestName: 'Phila Broderick',
    roomNo: '1', 
    arrival: new Date(), 
    departure: new Date("2021-03-25")
  }
]


@Injectable({
  providedIn: 'root'
})
export class InMemoryReservationService implements InMemoryDbService {

  createDb() {
    return {reservations};
  }

  get(reqInfo: RequestInfo) {
    return reqInfo.utils.createResponse$(() => {
      
      let queryParams: Map<string, string[]> = reqInfo.query;

      if (queryParams.size > 0) {
        let arrival = queryParams.get("arrival")[0];

        // format is dd-MM-yyyy
        let parts = arrival.split('-');
        let date = new Date(parseInt(parts[2]),
                            parseInt(parts[1]) - 1, parseInt(parts[0]));
        
        let filteredReservations: Reservation[] = new Array();
        
        reservations.map(res => {
          let arrival = res.arrival
          // want to compare just dates and not time
          // if arrival == date - no breakfast will be served
          // if date > arrival and <= departure - breakfast will be served
          if (date.valueOf() > res.arrival.valueOf() && date.valueOf() <= res.departure.valueOf() ) {
            filteredReservations.push(res);
          }
        })

        const options: ResponseOptions = {
            body: filteredReservations,
            status: STATUS.OK
          }
        return this.finishOptions(options, reqInfo);
      }

    // return request as passthrough if no params
    return undefined;
    });
  }

  private finishOptions(options: ResponseOptions, {headers, url}: RequestInfo) {
    options.statusText = getStatusText(options.status);
    options.headers = headers;
    options.url = url;
    return options;
  }

}
