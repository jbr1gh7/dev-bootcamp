import { Component, OnInit } from '@angular/core';
import { EventBusService } from 'src/app/services/event-bus.service';

@Component({
  selector: 'app-table-control',
  templateUrl: './table-control.component.html',
  styleUrls: ['./table-control.component.css']
})
export class TableControlComponent implements OnInit {

  constructor(private eventBus: EventBusService) {

  }

  ngOnInit(): void {

  }

}
