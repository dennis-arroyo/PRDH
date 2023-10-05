

export class CovidCase {
  caseId: string = '';
  patientId: String = '';
  earliestPositiveOrderTestSampleCollectedDate: Date = new Date();
  earliestPositiveOrderTestType: string = ``;
  orderTestCount: number = 0;
}
