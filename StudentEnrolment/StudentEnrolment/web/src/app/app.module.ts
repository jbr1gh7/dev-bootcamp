import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { StudentTableComponent } from './components/student-table/student-table.component';
import { TableControlComponent } from './components/table-control/table-control.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    StudentTableComponent,
    TableControlComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
