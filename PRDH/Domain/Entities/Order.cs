namespace PRDH.Entities;

public class Order
{
    public string OrderTestId { get; set; }
    public string PatientId { get; set; }
    public string PatientAgeRange { get; set; }
    public string PatientSex { get; set; }
    public string PatientRegion { get; set; }
    public string PatientCity { get; set; }
    public string OrderTestCategory { get; set; }
    public string OrderTestType { get; set; }
    public DateTime SampleCollectedDate { get; set; }
    public DateTime ResultReportDate { get; set; }
    public string OrderTestResult { get; set; }
    public DateTime OrderTestCreatedAt { get; set; }
}