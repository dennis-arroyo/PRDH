﻿using Microsoft.AspNetCore.Mvc;
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

    public Task<ActionResult<List<LaboratoryTest>>> GenerateCovid19PositiveCases(string caseId, string patientId,
        DateTime earliestPositiveOrderTestSampleCollectedDate, int orderTestCount)
    {
        throw new NotImplementedException();
    }
}