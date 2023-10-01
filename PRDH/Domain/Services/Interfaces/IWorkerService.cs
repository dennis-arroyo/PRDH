using Microsoft.AspNetCore.Mvc;
using PRDH.Entities;

namespace PRDH.Domain.Services.Interfaces;

public interface IWorkerService
{
    Task<List<Order>> GetOrderTests(string orderTestId, string orderTestCategory, string orderTestType, 
        DateTime sampleCollectedStartDate, DateTime sampleCollectedEndDate, DateTime createdAtStartDate, DateTime createdAtEndDate);
}