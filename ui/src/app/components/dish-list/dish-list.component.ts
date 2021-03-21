import { DishService } from './../../core/services/dish.service';
import { Dish } from './../../shared/models/dish.model';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';



@Component({
  selector: 'app-dish-list',
  templateUrl: './dish-list.component.html',
  styleUrls: ['./dish-list.component.css']
})
export class DishListComponent implements OnInit {

  step: number;
  constructor(private dishService: DishService) { 
  }

  dishes$: Observable<Dish[]> = this.dishService.selectedDishes;

  ngOnInit(): void {
    this.dishes$.subscribe(res => {
      this.step = res.length;
    })
  }


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
