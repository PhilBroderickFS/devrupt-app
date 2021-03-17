import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-kitchen',
  templateUrl: './kitchen.component.html',
  styleUrls: ['./kitchen.component.css']
})
export class KitchenComponent implements OnInit {

  columnsToDisplay  = ['ref', 'name'];
  constructor() { }

  ngOnInit(): void {
  }

  onDateSelected($event: Event) {
    console.log($event);
  }
}
