import {Component, OnInit} from '@angular/core';
import { CovidCase } from "./covid-case";
import { CovidCaseService } from "./covid-case.service";
import {Form, FormBuilder, FormGroup, Validators} from '@angular/forms';


@Component({
  selector: 'app-covid-case',
  templateUrl: './covid-case.component.html',
  styleUrls: ['./covid-case.component.css']
})
export class CovidCaseComponent implements OnInit {

  covidCases: CovidCase[] | undefined;
  error: string | undefined;
  noDataError: boolean = false;

  searchForm = this.formBuilder.group({
    page: [null],
    pageSize: [null],
    startDate: [null],
    endDate: [null]
  });

  constructor(private covidCaseService: CovidCaseService, private formBuilder: FormBuilder) {}

  async ngOnInit() {
    try {
      this.covidCases = await this.covidCaseService.getCases(1, 5);
      if (!this.covidCases || this.covidCases.length === 0) {
        this.error = 'No COVID cases available.';
        this.noDataError = true;
      }
      console.log(this.covidCases);
    } catch (err) {
      this.error = 'Unable to fetch data. Please check your network connection.';
      this.noDataError = false;
    }
  }

  submit() {
    console.log('');
  }

  get startDate() {return this.searchForm.get('startDate')}
  get endDate() {return this.searchForm.get('endDate')}

}
