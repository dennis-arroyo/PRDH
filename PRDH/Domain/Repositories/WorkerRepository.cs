using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    public async ValueTask<Case?> FindAsync(Guid caseId)
    {
        return await _context.Cases.FindAsync(caseId);
    }
    
    // public Task<ActionResult<List<Case>>> FindAllAsync(int page, int pageSize, DateTime sampleCollectedStartDate, 
    //     DateTime sampleCollectedEndDate)
    // {
    //     throw new NotImplementedException();
    // }
    //
    public async Task<List<Case>> GetCases(int page, int pageSize)
    {
        var skipCount = (page - 1) * pageSize;
        return await _context.Cases
            .OrderBy(c => c.EarliestPositiveOrderTestSampleCollectedDate)
            .Skip(skipCount)
            .Take(pageSize)
            .ToListAsync();
    }
    
    public async Task<List<Case>> GetCasesForSummary(DateTime startDate, DateTime endDate)
    {
        return await _context.Cases
            .Where(c => c.EarliestPositiveOrderTestSampleCollectedDate >= startDate.Date 
                        && c.EarliestPositiveOrderTestSampleCollectedDate <= endDate.AddDays(1).Date)
            .OrderBy(c => c.EarliestPositiveOrderTestSampleCollectedDate)
            .ToListAsync();
    }
    
    public async Task<List<Case>> GetCasesByDateRange(DateTime startDate, DateTime endDate, int page, int pageSize)
    {
        var skipCount = (page - 1) * pageSize;
        return await _context.Cases
            .Where(c => c.EarliestPositiveOrderTestSampleCollectedDate >= startDate 
                        && c.EarliestPositiveOrderTestSampleCollectedDate <= endDate)
            .Skip(skipCount)
            .Take(pageSize)
            .ToListAsync();
    }
    
    
}