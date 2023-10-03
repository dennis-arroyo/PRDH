using Microsoft.AspNetCore.Mvc;
using PRDH.Domain.Services.Interfaces;
using PRDH.Entities;

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
    public async Task<ActionResult<Order>> GetOrderTests(string? orderTestId, string orderTestCategory, string orderTestType, 
        DateTime sampleCollectedStartDate, DateTime sampleCollectedEndDate, DateTime createdAtStartDate, DateTime createdAtEndDate)
    {
        var orderTests = await _workerService.GetOrderTests(orderTestId, orderTestCategory, orderTestType, 
            sampleCollectedStartDate, sampleCollectedEndDate, createdAtStartDate, createdAtEndDate);
        var groupedData = orderTests.GroupBy(item => item.PatientId);
        return Ok(groupedData);
    }
    
    [HttpGet("covid19Cases")]
    public async Task<ActionResult<Case>> GenerateCovid19PositiveCases()
    {
        return Ok();
    }
}