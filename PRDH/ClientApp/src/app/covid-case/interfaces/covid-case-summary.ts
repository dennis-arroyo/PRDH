import {CovidCase} from "./covid-case";

export interface CovidCaseSummary {
  sampleCollectedDate: Date;
  quantityOfCases: number;
  quantityOfCasesByMolecularTest: number;
  quantityOfCasesByAntigensTest: number;
  quantityOfCasesBySelfMadeAntigensTest: number;
  cases: CovidCase[]
}
