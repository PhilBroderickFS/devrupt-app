import { DishService } from './../../core/services/dish.service';
import { Observable } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { Set } from '../../shared/models/set.model';

@Component({
  selector: 'app-recommended-sets',
  templateUrl: './recommended-sets.component.html',
  styleUrls: ['./recommended-sets.component.css']
})
export class RecommendedSetsComponent implements OnInit {

  constructor(private dishService: DishService) { }

  selectedSet$ = this.dishService.selectedSet;
  sets$ = this.dishService.set$;
  
  ngOnInit(): void {
  }

  selectSet(name: string) {
    this.dishService.setSelectedSet(name);
  }

  isSelectedSet(name: string): boolean {
    return this.selectedSet$.value.name.toUpperCase() === name.toUpperCase();
  }
}
