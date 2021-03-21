import { DishService } from './../../core/services/dish.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-meal-set',
  templateUrl: './meal-set.component.html',
  styleUrls: ['./meal-set.component.css']
})
export class MealSetComponent implements OnInit {

  constructor(public dishService: DishService) { }

  ngOnInit(): void {
  }

}
