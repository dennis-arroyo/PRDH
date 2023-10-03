using Microsoft.AspNetCore.Mvc;
using PRDH.Domain.Models;

namespace PRDH.Domain.Repositories.Interfaces;

public interface IWorkerRepository
{
    Task<ActionResult<List<LaboratoryTest>>> GenerateCovid19PositiveCases(string caseId, string patientId, 
        DateTime earliestPositiveOrderTestSampleCollectedDate, int orderTestCount);
}