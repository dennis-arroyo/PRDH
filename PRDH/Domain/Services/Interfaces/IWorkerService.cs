using Microsoft.AspNetCore.Mvc;
using PRDH.Domain.Models;

namespace PRDH.Domain.Services.Interfaces;

public interface IWorkerService
{
    Task<List<LaboratoryTest>> GetOrderTests(string orderTestId, string orderTestCategory, string orderTestType, 
        DateTime sampleCollectedStartDate, DateTime sampleCollectedEndDate, DateTime createdAtStartDate, DateTime createdAtEndDate);
    Task<List<Case>> GenerateCovid19PositiveCases(string orderTestId, string orderTestCategory, string orderTestType, 
        DateTime sampleCollectedStartDate, DateTime sampleCollectedEndDate, DateTime createdAtStartDate, DateTime createdAtEndDate);

    ValueTask<Case?> GetCaseById(string id);
    Task<List<Case>> GetCases(int page, int pageSize);
    Task<List<CovidCaseSummary>> GetCovidCaseSummary(int page, int pageSize);
    Task<List<Case>> GetCasesByDateRange(DateTime startDate, DateTime endDate, int page, int pageSize);
}