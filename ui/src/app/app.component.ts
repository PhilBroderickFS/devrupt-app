import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Guacamole';
  defaultRoute = true;

  constructor(private location: Location, private router: Router) {
    router.events.subscribe((val) => {
      if (location.path() != '') {
        this.defaultRoute = false;
      } else {
        this.defaultRoute = true;
      }
    })
  }

  ngOnInit() {
    console.log(this.router.url);
  }
}
