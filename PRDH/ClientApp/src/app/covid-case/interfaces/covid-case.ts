

export interface CovidCase {
  caseId: string;
  patientId: String;
  earliestPositiveOrderTestSampleCollectedDate: Date;
  earliestPositiveOrderTestType: string;
  orderTestCount: number;
}
