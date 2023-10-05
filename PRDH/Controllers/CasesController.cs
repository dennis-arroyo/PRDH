using Microsoft.AspNetCore.Mvc;
using PRDH.Domain.Services.Interfaces;
using PRDH.Domain.Models;

namespace PRDH.Controllers;

[ApiController]
[Route("api/[controller]/")]
public class CasesController : ControllerBase
{

    private readonly IWorkerService _workerService;

    public CasesController(IWorkerService workerService)
    {
        _workerService = workerService;
    }

    [HttpGet("orderTests")]
    public async Task<ActionResult<LaboratoryTest>> GetOrderTests(string? orderTestId, string orderTestCategory, string orderTestType, 
        DateTime sampleCollectedStartDate, DateTime sampleCollectedEndDate, DateTime createdAtStartDate, DateTime createdAtEndDate)
    {
        var orderTests = await _workerService.GetOrderTests(orderTestId, orderTestCategory, orderTestType, 
            sampleCollectedStartDate, sampleCollectedEndDate, createdAtStartDate, createdAtEndDate);
        var groupedData = orderTests.GroupBy(item => item.PatientId).ToList();
        return Ok(groupedData);
    }
    
    [HttpGet("covid19Cases")]
    public async Task<ActionResult<Case>> GenerateCovid19PositiveCases(string? orderTestId, string orderTestCategory, string orderTestType, 
        DateTime sampleCollectedStartDate, DateTime sampleCollectedEndDate, DateTime createdAtStartDate, DateTime createdAtEndDate)
    {
        var positiveCases = await _workerService.GenerateCovid19PositiveCases(orderTestId, orderTestCategory, orderTestType, 
            sampleCollectedStartDate, sampleCollectedEndDate, createdAtStartDate, createdAtEndDate);
        return Ok(positiveCases);
    }

    [HttpGet("getCaseById")]
    public async ValueTask<Case?> GetCaseById(string caseId)
    {
        var caseResult = await _workerService.GetCaseById(caseId);
        return caseResult;
    }
    
    [HttpGet("getCases")]
    public async Task<List<Case>> GetCases(int page = 1, int pageSize = 10)
    {
        var caseResult = await _workerService.GetCases(page, pageSize);
        return caseResult;
    }
    
    [HttpGet("getCovidCaseSummary")]
    public async Task<List<CovidCaseSummary>> GetCovidCaseSummary(int page = 1, int pageSize = 10)
    {
        var caseResult = await _workerService.GetCovidCaseSummary(page, pageSize);
        return caseResult;
    }
    
    [HttpGet("getCaseByDateRange")]
    public async Task<List<Case>> GetCasesByDateRange(DateTime startDate, DateTime endDate, int page = 1, int pageSize = 10)
    {
        var caseResult = await _workerService.GetCasesByDateRange(startDate, endDate, page, pageSize);
        return caseResult;
    }
    
}