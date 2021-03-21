import { Observable, of } from 'rxjs';
import { Injectable } from '@angular/core';
import { Set } from '../../shared/models/set.model';
import { Ingredient } from 'src/app/shared/models/ingredient.model';

@Injectable({
  providedIn: 'root'
})
export class DishService {

  sets: Set[] = [
    {
      name: "Set A",
      compatability: 70,
      dishes: [
        {
          name: "Dish A",
          ingredients: [
            {
              name: "Ingredient A",
              amount: 3,
              measurement: "kg"
            }
          ]
        },
        {
          name: "Dish B",
          ingredients: [
            {
              name: "Ingredient A",
              amount: 3,
              measurement: "kg"
            },
            {
              name: "Ingredient B",
              amount: 200,
              measurement: "ml"
            }
          ]
        }
      ]
    },
    {
      name: "Set A",
      compatability: 70,
      dishes: [
        {
          name: "Dish A",
          ingredients: [
            {
              name: "Ingredient A",
              amount: 3,
              measurement: "kg"
            }
          ]
        },
        {
          name: "Dish B",
          ingredients: [
            {
              name: "Ingredient A",
              amount: 3,
              measurement: "kg"
            },
            {
              name: "Ingredient B",
              amount: 200,
              measurement: "ml"
            }
          ]
        }
      ]
    },
    {
      name: "Set A",
      compatability: 70,
      dishes: [
        {
          name: "Dish A",
          ingredients: [
            {
              name: "Ingredient A",
              amount: 3,
              measurement: "kg"
            }
          ]
        },
        {
          name: "Dish B",
          ingredients: [
            {
              name: "Ingredient A",
              amount: 3,
              measurement: "kg"
            },
            {
              name: "Ingredient B",
              amount: 200,
              measurement: "ml"
            }
          ]
        }
      ]
    }
  ]

  constructor() { }
  
  getSets(date: Date): Observable<Set[]> {
    return of(this.sets);
  }

  
  getIngredientTotals(): Observable<Ingredient[]> {
    let map = new Map();
    this.sets.map(set => {
      set.dishes.map(dish => {
        dish.ingredients.forEach(ingredient => {
          if (!map.has(ingredient.name)) {
            map.set(ingredient.name, ingredient);
          } else {
            let currIngred: Ingredient = map.get(ingredient.name);
            currIngred.amount += ingredient.amount;
            map.set(currIngred.name, currIngred);
          }
        })
      })
    })
    let result: Ingredient[] = [];
    map.forEach(ingredient => result.push(ingredient));
    return of(result);
  }
}
