import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HttpClientModule } from "@angular/common/http";
import { CovidCaseComponent } from './covid-case/covid-case.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NavbarComponent } from './navbar/navbar.component';
import { CovidCaseTableComponent } from './covid-case/covid-case-table/covid-case-table.component';
import { CovidCaseSummaryTableComponent } from './covid-case/covid-case-summary-table/covid-case-summary-table.component';

@NgModule({
  declarations: [
    AppComponent,
    CovidCaseComponent,
    NavbarComponent,
    CovidCaseTableComponent,
    CovidCaseSummaryTableComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
