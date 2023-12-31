import {Component, OnInit} from '@angular/core';
import { CovidCase } from "./interfaces/covid-case";
import { CovidCaseService } from "./covid-case.service";
import {Form, FormBuilder, FormGroup, Validators} from '@angular/forms';
import {CovidCaseSummary} from "./interfaces/covid-case-summary";


@Component({
  selector: 'app-covid-case',
  templateUrl: './covid-case.component.html',
  styleUrls: ['./covid-case.component.css']
})
export class CovidCaseComponent implements OnInit {

  private defaultStartDate: string = '2023-01-01';
  private defaultEndDate: string = '2023-01-10';
  public page: number = 1;
  public pageSize: number = 10;
  public disablePagination: boolean = false;

  // covidCases: CovidCase[] | undefined;
  covidCaseSummaries: CovidCaseSummary[] | undefined;
  error: string | undefined;
  noDataError: boolean = false;

  searchForm = this.formBuilder.group({
    startDate: [this.defaultStartDate],
    endDate: [this.defaultEndDate]
  });

  constructor(private covidCaseService: CovidCaseService, private formBuilder: FormBuilder) {}

  ngOnInit() {
    this.fetchCovidCaseSummaries(this.page, this.pageSize);
  }

  // For future use in case I want to retrieve the cases instead of summary.
  // fetchCases() {
  //   this.covidCaseService.getCases(1, 5).subscribe({
  //     next: (data) => {
  //       this.covidCases = data;
  //       if (!this.covidCases || this.covidCases.length === 0) {
  //         this.error = 'No COVID cases available.';
  //         this.noDataError = true;
  //       }
  //     },
  //     error: (error) => {
  //       this.error = 'Unable to fetch data. Please check your network connection.';
  //       this.noDataError = false;
  //       console.error(error); // Log the error for debugging purposes
  //     }
  //   });
  // }

  fetchCovidCaseSummaries(page: number, pageSize: number = 10) {
    this.page = page > 0 ? page : 1;
    this.pageSize = pageSize;
    let startDate = this.startDate?.value
    let endDate = this.endDate?.value
    startDate = startDate ? startDate : this.defaultStartDate;
    endDate = endDate ? endDate : this.defaultEndDate;
    this.covidCaseService.getCovidCaseSummaries(startDate, endDate, this.page,this.pageSize).subscribe({
      next: (data) => {
        this.covidCaseSummaries = data;
        if (!this.covidCaseSummaries || this.covidCaseSummaries.length === 0) {
          this.error = 'No COVID cases available.';
          this.noDataError = true;
        } else {
          this.noDataError = false;
          this.error = undefined;
        }
        this.disablePagination = this.covidCaseSummaries && this.covidCaseSummaries.length < 10;
      },
      error: (error) => {
        this.error = 'Unable to fetch data. Please check your network connection.';
        this.noDataError = false;
        this.disablePagination = true;
        console.error(error);
      }
    });
  }

  submit() {
    this.page = 1;
    this.pageSize = 10;
    this.fetchCovidCaseSummaries(this.page, this.pageSize);
  }

  get startDate() {return this.searchForm.get('startDate')}
  get endDate() {return this.searchForm.get('endDate')}

}
