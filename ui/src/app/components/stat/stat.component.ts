import { Stat } from './../../shared/models/stat.model';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-stat',
  templateUrl: './stat.component.html',
  styleUrls: ['./stat.component.css']
})
export class StatComponent implements OnInit {

  @Input() header: string;
  @Input() icon: string;
  @Input() statList: Stat[];
  
  constructor() { }

  ngOnInit(): void {
  }

}
