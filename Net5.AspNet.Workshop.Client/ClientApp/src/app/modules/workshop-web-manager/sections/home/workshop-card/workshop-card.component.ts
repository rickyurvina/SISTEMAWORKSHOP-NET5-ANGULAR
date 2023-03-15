import { Component, Input, OnInit } from '@angular/core';
import { Workshop } from '../../../../../models/workshop';

@Component({
  selector: 'app-workshop-card',
  templateUrl: './workshop-card.component.html',
  styleUrls: ['./workshop-card.component.scss']
})
export class WorkshopCardComponent implements OnInit {
  @Input() workshop = new Workshop();

  constructor() { }

  ngOnInit(): void {
    
  }

}
