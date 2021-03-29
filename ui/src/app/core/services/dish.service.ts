import { environment } from './../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable, of, BehaviorSubject } from 'rxjs';
import { Injectable } from '@angular/core';
import { Set } from '../../shared/models/set.model';
import { Ingredient } from 'src/app/shared/models/ingredient.model';
import { Dish } from 'src/app/shared/models/dish.model';
import { map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DishService {

  private apiUrl = `${environment.apiBaseUrl}/Recommendation`;

  sets: Set[] = [

  ]

  public dishesPerSet: BehaviorSubject<number> = new BehaviorSubject<number>(5);
  filteredSetList = this.filterDishesPerSets();

  public set$: BehaviorSubject<Set[] | null> = new BehaviorSubject(null);
  public selectedSet: BehaviorSubject<Set | null> = new BehaviorSubject(null);
  public selectedDishes: BehaviorSubject<Dish[]| null> = new BehaviorSubject(null);
  public selectedIngredientTotals: BehaviorSubject<Ingredient[]| null> = new BehaviorSubject(null);

  constructor(private httpClient: HttpClient) { }

  setSelectedSet(name: string) {
    let newSelectedSet = this.filteredSetList.find(set => set.name.toUpperCase() === name.toUpperCase());
    this.selectedSet.next(newSelectedSet);
    this.selectedDishes.next(newSelectedSet.dishes);
    this.selectedIngredientTotals.next(this.getIngredientTotals());
  }

  getSets(guestIds: string[]): Observable<Set[]> {
    return this.httpClient.post<Set[]>(this.apiUrl, { 'numberOfDishes': this.dishesPerSet.value, 'guestIds': guestIds})
      .pipe(
        map(sets => {
          this.sets = sets;
          this.selectedSet.next(this.sets[0]);
          this.updateObservables();
          return sets;
        })
      );
  }

  setDishNumber(numOfDishes: number) {
    this.dishesPerSet.next(numOfDishes);
    this.updateObservables();
  }

  filterDishesPerSets() : Set[] {
    let sets: Set[] = new Array();
    this.sets.map(set => {
      let dishes = set.dishes.slice(0, this.dishesPerSet.value);
      let filteredDishSet = {...set};
      filteredDishSet.dishes = dishes;
      sets.push(filteredDishSet);
    })
    return sets;
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

  private updateObservables() {
    this.filteredSetList = this.filterDishesPerSets();
    let selectedSetName = this.selectedSet.value.name;
    this.set$.next(this.filteredSetList);
    this.selectedSet.next(this.filteredSetList.filter(set => set.name.toUpperCase() === selectedSetName.toUpperCase())[0]);
    this.selectedDishes.next(this.selectedSet.value.dishes);
    this.selectedIngredientTotals.next(this.getIngredientTotals());
  }
}
