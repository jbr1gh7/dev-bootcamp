import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventBusService {
  private addEventSource = new BehaviorSubject<boolean>(false);
  isAddingEvent = this.addEventSource.asObservable();

  constructor() { }

  showHideRow(isAdding: boolean): void {
    this.addEventSource.next(isAdding);
  }
}
