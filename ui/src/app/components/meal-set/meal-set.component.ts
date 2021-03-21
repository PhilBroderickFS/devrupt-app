import { DishNumberSelectionDialogComponent } from './../dish-number-selection-dialog/dish-number-selection-dialog.component';
import { DishService } from './../../core/services/dish.service';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-meal-set',
  templateUrl: './meal-set.component.html',
  styleUrls: ['./meal-set.component.css']
})
export class MealSetComponent implements OnInit {

  constructor(public dishService: DishService, public dialog: MatDialog) { }

  ngOnInit(): void {
  }

  openDialog() {
    const dialogRef = this.dialog.open(DishNumberSelectionDialogComponent, {
      width: '350px',
      data: {numOfDishes: 3}
    });
  }

}
