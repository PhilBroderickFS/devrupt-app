import { GuestBookingsService } from './../../core/services/guest-bookings.service';
import { DishService } from './../../core/services/dish.service';
import { Observable } from 'rxjs';
import { Component, OnInit, Input } from '@angular/core';
import { Set } from '../../shared/models/set.model';

@Component({
  selector: 'app-recommended-sets',
  templateUrl: './recommended-sets.component.html',
  styleUrls: ['./recommended-sets.component.css']
})
export class RecommendedSetsComponent implements OnInit {

  @Input() guestIds: string[];

  constructor(private dishService: DishService, private guestBookingsService: GuestBookingsService) { }

  sets$ = this.dishService.set$;
  selectedSet$ = this.dishService.selectedSet;
  
  ngOnInit(): void {
    this.dishService.getSets(this.guestBookingsService.guestIds).subscribe(res => console.log(res));
  }

  selectSet(name: string) {
    this.dishService.setSelectedSet(name);
  }

  isSelectedSet(name: string): boolean {
    return this.selectedSet$.value.name.toUpperCase() === name.toUpperCase();
  }
}
