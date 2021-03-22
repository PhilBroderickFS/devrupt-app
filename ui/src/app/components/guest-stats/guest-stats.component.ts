import { StatData } from './../../shared/models/stat-data.model';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-guest-stats',
  templateUrl: './guest-stats.component.html',
  styleUrls: ['./guest-stats.component.css']
})
export class GuestStatsComponent implements OnInit {

  statDataList: StatData[] = [
    {
      category: "Allergies",
      icon: "no_meals",
      statList: [
        {
          description: "Lactose intolerance",
          number: 2
        },
        {
          description: "Egg allergy",
          number: 1
        },
        {
          description: "Nut allergy",
          number: 1
        },
        {
          description: "Other allergies",
          number: 1
        }
      ]
    },
    {
      category: "Dietary Requirements",
      icon: "grass",
      statList: [
        {
          description: "Vegetarian guests",
          number: 2
        },
        {
          description: "Pescatarian guests",
          number: 1
        },
        {
          description: "Vegan guests",
          number: 2
        },
        {
          description: "Other requirements",
          number: 1
        }
      ]
    },
    {
      category: "Age Groups",
      icon: "groups",
      statList: [
        {
          description: "< 16 y.o.",
          number: 0
        },
        {
          description: "16 - 24 y.o.",
          number: 2
        },
        {
          description: "24 - 54 y.o.",
          number: 2
        },
        {
          description: "> 54 y.o.",
          number: 2
        }
      ]
    }
  ]
  constructor() { }

  ngOnInit(): void {
  }

}
