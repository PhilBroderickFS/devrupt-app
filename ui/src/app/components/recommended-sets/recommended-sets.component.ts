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

  sets$: Observable<Set[]> = this.dishService.getSets(new Date);
  ngOnInit(): void {
  }

}
