import { DialogData } from './../../shared/dialog.data';
import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-dish-number-selection-dialog',
  templateUrl: './dish-number-selection-dialog.component.html',
  styleUrls: ['./dish-number-selection-dialog.component.css']
})
export class DishNumberSelectionDialogComponent {

  constructor(
    public dialogRef: MatDialogRef<DishNumberSelectionDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) { }


  onCloseClick() {
    this.dialogRef.close();
  }

  decrementDishes = () => this.data.numOfDishes--;

  incrementDishes = () => this.data.numOfDishes++;
}
