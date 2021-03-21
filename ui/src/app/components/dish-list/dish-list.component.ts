import { Dish } from './../../shared/models/dish.model';
import { Component, OnInit } from '@angular/core';


const DATA: Dish[] = [
  { 
    name: 'Dish A', 
    ingredients: [
      { 
        name: 'Ingredient A',
        amount: 3,
        measurement: "kg"
      }
    ]
  },
  { 
    name: 'Dish B', 
    ingredients: [
      { 
        name: 'Ingredient A',
        amount: 3,
        measurement: "kg"
      },
      { 
        name: 'Ingredient B',
        amount: 200,
        measurement: "ml"
      }
    ]
  }
]


@Component({
  selector: 'app-dish-list',
  templateUrl: './dish-list.component.html',
  styleUrls: ['./dish-list.component.css']
})
export class DishListComponent implements OnInit {

  step = DATA.length;

  dishes: Dish[] = DATA;
  constructor() { 
  }

  ngOnInit(): void {}


  setStep(index: number) {
    this.step = index;
  }

  nextStep() {
    this.step++;
  }

  prevStep() {
    this.step--;
  }
}
