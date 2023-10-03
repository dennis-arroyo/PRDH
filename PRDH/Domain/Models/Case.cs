using System.ComponentModel.DataAnnotations;

namespace PRDH.Domain.Models;

public class Case
{
    [Key]
    public Guid CaseId { get; set; }
    public Guid PatientId { get; set; }
    public DateTime EarliestPositiveOrderTestSampleCollectedDate { get; set; }
    public string? EarliestPositiveOrderTestType { get; set; }
    public int OrderTestCount { get; set; }
}