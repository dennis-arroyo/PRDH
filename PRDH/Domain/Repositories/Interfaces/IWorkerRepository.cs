using Microsoft.AspNetCore.Mvc;
using PRDH.Domain.Models;

namespace PRDH.Domain.Repositories.Interfaces;

public interface IWorkerRepository
{
    Task<List<Case>> AddCases(List<Case> cases);
    ValueTask<Case?> FindAsync(Guid caseId);
    Task<List<Case>> GetCases(int page, int pageSize);
    Task<List<Case>> GetCasesForSummary();
    Task<List<Case>> GetCasesByDateRange(DateTime startDate, DateTime endDate, int page, int pageSize);
}