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
}