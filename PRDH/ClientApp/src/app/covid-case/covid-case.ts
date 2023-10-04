

export class CovidCase {
  CaseId: string = '';
  PatientId: String = '';
  EarliestPositiveOrderTestSampleCollectedDate: Date = new Date();
  EarliestPositiveOrderTestType: string = ``;
  OrderTestCount: number = 0;
}
