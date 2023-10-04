import {Component, OnInit} from '@angular/core';
import { CovidCase } from "./covid-case";
import {CovidCaseService} from "./covid-case.service";


@Component({
  selector: 'app-covid-case',
  templateUrl: './covid-case.component.html',
  styleUrls: ['./covid-case.component.css']
})
export class CovidCaseComponent implements OnInit {
  covidCases: CovidCase[] | undefined;
  constructor(private covidCaseService: CovidCaseService) {}

  async ngOnInit() {
    this.covidCases = await this.covidCaseService.getCases(1, 5);
    console.log(this.covidCases);
  }

}
