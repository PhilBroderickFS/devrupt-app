import { Observable, of, BehaviorSubject } from 'rxjs';
import { Injectable } from '@angular/core';
import { Day } from 'src/app/shared/models/day.model';

@Injectable({
  providedIn: 'root'
})
export class CalenderService {
  days: Day[] = new Array();

  public dateSelected: BehaviorSubject<Date> = new BehaviorSubject(new Date);

  constructor() { }

  getNextNDays(numOfDays: number) : Observable<Day[]> {
    let today = new Date();
    for (let i = 0; i < numOfDays; i++) {
      let date = new Date(today);
      date.setDate(date.getDate() + i);
      const day = new Day(date);
      this.days.push(day);
    }

    return of(this.days);
  }


}
