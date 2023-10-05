namespace PRDH.Domain.Models;

public class CovidCaseSummary
{
    public DateTime SampleCollectedDate { get; set; }
    public int QuantityOfCases { get; set; }
    public int QuantityOfCasesByMolecularTest { get; set; }
    public int QuantityOfCasesByAntigensTest { get; set; }
    public int QuantityOfCasesBySelfMadeAntigensTest { get; set; }
    public List<Case>? Cases { get; set; }
}