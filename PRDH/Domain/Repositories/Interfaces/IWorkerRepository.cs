using Microsoft.AspNetCore.Mvc;
using PRDH.Domain.Models;

namespace PRDH.Domain.Repositories.Interfaces;

public interface IWorkerRepository
{
    Task<List<Case>> AddCases(List<Case> cases);
    // Task<ActionResult<Case>> FindAsync(Guid caseId);
    // Task<ActionResult<List<Case>>> FindAllAsync(DateTime sampleCollectedStartDate, DateTime sampleCollectedEndDate);
    // Task<ActionResult<List<Case>>> FindAllAsync();
}