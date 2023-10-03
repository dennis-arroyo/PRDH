using Microsoft.AspNetCore.Mvc;
using PRDH.Domain.Models;

namespace PRDH.Domain.Services.Interfaces;

public interface IWorkerService
{
    Task<List<LaboratoryTest>> GetOrderTests(string orderTestId, string orderTestCategory, string orderTestType, 
        DateTime sampleCollectedStartDate, DateTime sampleCollectedEndDate, DateTime createdAtStartDate, DateTime createdAtEndDate);
    Task<List<Case>> GenerateCovid19PositiveCases(string orderTestId, string orderTestCategory, string orderTestType, 
        DateTime sampleCollectedStartDate, DateTime sampleCollectedEndDate, DateTime createdAtStartDate, DateTime createdAtEndDate);
}