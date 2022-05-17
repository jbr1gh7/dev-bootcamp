import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-table-control',
  templateUrl: './table-control.component.html',
  styleUrls: ['./table-control.component.css']
})
export class TableControlComponent implements OnInit {
  entity: string;

  constructor() {
    this.entity = 'student';
  }

  ngOnInit(): void {
  }

}
