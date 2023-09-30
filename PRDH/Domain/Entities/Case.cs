using System.ComponentModel.DataAnnotations;

namespace PRDH_API.Entities;

public class Case
{
    [Key]
    public Guid CaseId { get; set; }
    public Guid PatientId { get; set; }
    public DateTime EarliestPositiveOrderTestSampleCollectedDate { get; set; }
    public DateTime EarliestPositiveOrderTestType { get; set; }
    public int OrderTestCount { get; set; }
}