import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { CovidCase } from "./interfaces/covid-case";
import { environment } from "../../environments/environment";
import {CovidCaseSummary} from "./interfaces/covid-case-summary";

@Injectable({
  providedIn: 'root'
})
export class CovidCaseService {
  private endpoint = `${environment.api}`;

  constructor(private http: HttpClient) { }

  public getCases(page: number, pageSize: number) {
    let params = new HttpParams();
    if (page) {
      params = params.set('page', page.toString());
    }
    if (pageSize) {
      params = params.set('pageSize', pageSize.toString());
    }

    return this.http.get<CovidCase[]>(`${this.endpoint}/api/Cases/getCases`, {
      params: params
    });
  }

  public getCovidCaseSummaries(startDate: string, endDate: string, page: number, pageSize: number) {
    let params = new HttpParams();
    if (startDate) {
      params = params.set('startDate', startDate);
    }
    if (endDate) {
      params = params.set('endDate', endDate);
    }
    if (page) {
      params = params.set('page', page.toString());
    }
    if (pageSize) {
      params = params.set('pageSize', pageSize.toString());
    }
    console.log(params);
    return this.http.get<CovidCaseSummary[]>(`${this.endpoint}/api/Cases/getCovidCaseSummary`, {
      params: params
    });
  }
}
