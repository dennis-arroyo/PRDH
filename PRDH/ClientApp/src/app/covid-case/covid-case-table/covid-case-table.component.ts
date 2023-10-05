import {Component, Input} from '@angular/core';
import {CovidCase} from "../covid-case";

@Component({
  selector: 'app-covid-case-table',
  templateUrl: './covid-case-table.component.html',
  styleUrls: ['./covid-case-table.component.css']
})

export class CovidCaseTableComponent {
  @Input() covidCases: CovidCase[] | undefined;
  @Input() error: string | undefined;
  @Input() noDataError: boolean = false;

  regenerateData() {
    console.log('Regenerating data...')
  }
}
