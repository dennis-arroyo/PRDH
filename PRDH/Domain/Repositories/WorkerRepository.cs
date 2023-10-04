using Microsoft.AspNetCore.Mvc;
using PRDH.Domain.Repositories.Interfaces;
using PRDH.Data;
using PRDH.Domain.Models;

namespace PRDH.Domain.Repositories;

public class WorkerRepository : IWorkerRepository
{
    private readonly DataContext _context;

    public WorkerRepository(DataContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<List<Case>> AddCases(List<Case> cases)
    {
        foreach (var caseItem in cases)
        {
            _context.Cases.Add(caseItem);
        }

        await _context.SaveChangesAsync();
        return cases;
    }

    // public Task<ActionResult<Case>> FindAsync(Guid caseId)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public Task<ActionResult<List<Case>>> FindAllAsync(DateTime sampleCollectedStartDate, DateTime sampleCollectedEndDate)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public Task<ActionResult<List<Case>>> FindAllAsync()
    // {
    //     throw new NotImplementedException();
    // }
}