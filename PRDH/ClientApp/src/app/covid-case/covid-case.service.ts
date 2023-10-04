import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import {CovidCase} from "./covid-case";
import {environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class CovidCaseService {
  private endpoint = `${environment.api}`;

  constructor(private http: HttpClient) { }

  public async getCases(page: number, pageSize: number) {
    try {
      let params = new HttpParams();
      if (page) {
        params = params.set('page', page.toString());
      }
      if (pageSize) {
        params = params.set('pageSize', pageSize.toString());
      }

      const covidCases = await this.http.get<CovidCase[]>(`${this.endpoint}/api/Cases/getCases`, {
        params: params
      }).toPromise();

      // const covidCases = await this.http.get<CovidCase[]>(`${this.endpoint}/page=${page}/pageSize=${pageSize}`).toPromise();

      return covidCases;

    } catch (err) {
      console.log(err);
      throw err;
    }
  }
}
