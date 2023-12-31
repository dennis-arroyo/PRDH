﻿using Microsoft.AspNetCore.Mvc;
using PRDH.Domain.Repositories.Interfaces;
using PRDH.Domain.Services.Interfaces;
using PRDH.Domain.Models;

namespace PRDH.Domain.Services;

public class WorkerService : IWorkerService
{

    private const string PRDH_API_URI = "https://biostatistics.salud.pr.gov";
    private readonly IWorkerRepository _workerRepository;

    public WorkerService(IWorkerRepository workerRepository)
    {
        _workerRepository = workerRepository;
    }

    public async Task<List<LaboratoryTest>> GetOrderTests(string orderTestId, string orderTestCategory, string orderTestType,
        DateTime sampleCollectedStartDate, DateTime sampleCollectedEndDate, DateTime createdAtStartDate,
        DateTime createdAtEndDate)
    {
        var httpClient = new HttpClient
        {
            Timeout = Timeout.InfiniteTimeSpan
        };
        var endpoint = "orders/tests/covid-19/minimal";
        
        // Create a UriBuilder and add query parameters
        var uriBuilder = new UriBuilder($"{PRDH_API_URI}/{endpoint}");
        var query = new List<string>();

        void AddQueryParam(string paramName, string paramValue)
        {
            if (!string.IsNullOrWhiteSpace(paramValue))
            {
                query.Add($"{paramName}={Uri.EscapeDataString(paramValue)}");
            }
        }
        
        AddQueryParam("OrderTestId",orderTestId);
        AddQueryParam("OrderTestCategory",orderTestCategory);
        AddQueryParam("OrderTestType","");
        AddQueryParam("SampleCollectedStartDate",$"{sampleCollectedStartDate:o}");
        AddQueryParam("SampleCollectedEndDate",$"{sampleCollectedEndDate:o}");
        AddQueryParam("CreatedAtStartDate",$"{createdAtStartDate:o}");
        AddQueryParam("CreatedAtEndDate",$"{createdAtEndDate:o}");
        
        uriBuilder.Query = string.Join("&", query);
        
        HttpResponseMessage response = await httpClient.GetAsync(uriBuilder.Uri);
        return response.IsSuccessStatusCode switch
        {
            true => await response.Content.ReadFromJsonAsync<List<LaboratoryTest>>() ?? throw new InvalidOperationException(),
            _ => throw new HttpRequestException($"API request failed with status code: {response.StatusCode}")
        };
    }

    public async Task<List<Case>> GenerateCovid19PositiveCases(string orderTestId, string orderTestCategory, string orderTestType,
        DateTime sampleCollectedStartDate, DateTime sampleCollectedEndDate, DateTime createdAtStartDate,
        DateTime createdAtEndDate)
    {
        var laboratoryTests = await GetOrderTests(orderTestId, orderTestCategory, orderTestType, sampleCollectedStartDate,
            sampleCollectedEndDate, createdAtStartDate, createdAtEndDate);

        var groupedOrderTests = laboratoryTests
            .Where(test => test.OrderTestResult == "Positive")
            .GroupBy(test => test.PatientId)
            .ToList();

        var cases = new List<Case>();

        foreach (var testGroup in groupedOrderTests)
        {
            var firstPositiveTest = testGroup
                .OrderBy(test => test.SampleCollectedDate)
                .First();

            cases.Add(new Case
            {
                CaseId = Guid.NewGuid(),
                PatientId = firstPositiveTest.PatientId,
                EarliestPositiveOrderTestSampleCollectedDate = firstPositiveTest.SampleCollectedDate,
                EarliestPositiveOrderTestType = firstPositiveTest.OrderTestType,
                OrderTestCount = testGroup.Count()
            });
        }

        // return cases;
        return await _workerRepository.AddCases(cases);
    }

    public async ValueTask<Case?> GetCaseById(string id)
    {
        var guidId = new Guid(id);
        return await _workerRepository.FindAsync(guidId);
    }

    public async Task<List<Case>> GetCases(int page = 1, int pageSize = 10)
    {
        return await _workerRepository.GetCases(page, pageSize);
    }
    
    public async Task<List<CovidCaseSummary>> GetCovidCaseSummary(DateTime startDate, DateTime endDate, int page = 1, int pageSize = 10)
    {
        var cases = await _workerRepository.GetCasesForSummary(startDate, endDate);

        var groupedCases = cases
            .GroupBy(c => c.EarliestPositiveOrderTestSampleCollectedDate.Date)
            .Select(item => new CovidCaseSummary()
            {
                SampleCollectedDate = item.Key,
                QuantityOfCases = item.Count(),
                QuantityOfCasesByMolecularTest = item.Count(c => c.EarliestPositiveOrderTestType == "Molecular"),
                QuantityOfCasesByAntigensTest = item.Count(c => c.EarliestPositiveOrderTestType == "Antigens"),
                QuantityOfCasesBySelfMadeAntigensTest = item.Count(c => c.EarliestPositiveOrderTestType == "AntigensSelfTest"),
                Cases = item.ToList()
            })
            .ToList();

        // I could use it in the future to display in the front-end the total amount of items for pagination.
        var totalCount = groupedCases.Count;

        var pagedSummaries = groupedCases.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        return pagedSummaries;
    }


    public async Task<List<Case>> GetCasesByDateRange(DateTime startDate, DateTime endDate, int page, int pageSize)
    {
        return await _workerRepository.GetCasesByDateRange(startDate, endDate, page, pageSize);
    }
}