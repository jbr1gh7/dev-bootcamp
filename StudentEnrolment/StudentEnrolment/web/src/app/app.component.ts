import { Component } from '@angular/core';
import { EventBusService } from './services/event-bus.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title: string = 'Student Enrolment';

  constructor(private eventBus: EventBusService) {

  }
}
