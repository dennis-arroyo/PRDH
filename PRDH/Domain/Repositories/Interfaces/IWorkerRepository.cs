using Microsoft.AspNetCore.Mvc;
using PRDH.Entities;

namespace PRDH.Domain.Repositories.Interfaces;

public interface IWorkerRepository
{
    Task<ActionResult<List<Order>>> GenerateCovid19PositiveCases(string caseId, string patientId, 
        DateTime earliestPositiveOrderTestSampleCollectedDate, int orderTestCount);
}