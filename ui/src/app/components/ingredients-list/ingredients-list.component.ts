import { DishService } from './../../core/services/dish.service';
import { Observable } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { Ingredient } from 'src/app/shared/models/ingredient.model';

@Component({
  selector: 'app-ingredients-list',
  templateUrl: './ingredients-list.component.html',
  styleUrls: ['./ingredients-list.component.css']
})
export class IngredientsListComponent implements OnInit {

  constructor(private dishService: DishService) { }

  totalIngredients$: Observable<Ingredient[]> = this.dishService.getIngredientTotals();

  ngOnInit(): void {
  }

}
