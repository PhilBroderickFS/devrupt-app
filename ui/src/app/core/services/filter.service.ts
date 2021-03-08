import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FilterService {

  public filter: Subject<string> = new Subject();
  constructor() { }
}
