import {Component, Input} from '@angular/core';
import {CovidCase} from "../interfaces/covid-case";
import {CovidCaseSummary} from "../interfaces/covid-case-summary";

@Component({
  selector: 'app-covid-case-summary-table',
  templateUrl: './covid-case-summary-table.component.html',
  styleUrls: ['./covid-case-summary-table.component.css']
})
export class CovidCaseSummaryTableComponent {
  @Input() covidCaseSummary: CovidCaseSummary[] | undefined;
  @Input() error: string | undefined;
  @Input() noDataError: boolean = false;

  regenerateData() {}
}
