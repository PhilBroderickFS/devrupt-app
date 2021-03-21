import { Observable, of, BehaviorSubject } from 'rxjs';
import { Injectable } from '@angular/core';
import { Set } from '../../shared/models/set.model';
import { Ingredient } from 'src/app/shared/models/ingredient.model';
import { Dish } from 'src/app/shared/models/dish.model';

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
      name: "Set B",
      compatability: 60,
      dishes: [
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
      name: "Set C",
      compatability: 45,
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
        },
        {
          name: "Dish C",
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

  public set$: BehaviorSubject<Set[]> = new BehaviorSubject(this.sets);
  public selectedSet: BehaviorSubject<Set> = new BehaviorSubject(this.sets[0]);
  public selectedDishes: BehaviorSubject<Dish[]> = new BehaviorSubject<Dish[]>(this.selectedSet.value.dishes);
  public selectedIngredientTotals: BehaviorSubject<Ingredient[]> = new BehaviorSubject<Ingredient[]>(this.getIngredientTotals())

  constructor() { }
  
  setSelectedSet(name: string) {
    let newSelectedSet = this.sets.find(set => set.name.toUpperCase() === name.toUpperCase());
    this.selectedSet.next(newSelectedSet);
    this.selectedDishes.next(newSelectedSet.dishes);
    this.selectedIngredientTotals.next(this.getIngredientTotals());
  }

  getSets(date: Date): Observable<Set[]> {
    return of(this.sets);
  }

  getIngredientTotals(): Ingredient[] {
    let map = new Map();
    this.selectedDishes.value.map(dish => {
      dish.ingredients.forEach(ingredient => {
        if (!map.has(ingredient.name)) {
          map.set(ingredient.name, {...ingredient});
        } else {
          let currIngred: Ingredient = map.get(ingredient.name);
          currIngred.amount += ingredient.amount;
          map.set(currIngred.name, currIngred);
        }
      })
    })
    let result: Ingredient[] = [];
    map.forEach(ingredient => result.push(ingredient));
    return result;
  }

  applyCurrentSet() {
    this.sets = this.sets.filter(set => set.name.toUpperCase() === this.selectedSet.value.name.toUpperCase());
    let selectedSet = this.sets[0];
    this.setSelectedSet(selectedSet.name);
    this.set$.next(this.sets);
  }
}
