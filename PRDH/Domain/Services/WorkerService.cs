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
        var httpClient = new HttpClient();
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


    //
    // public async Task<List<Case>> GetCases(int page, int pageSize)
    // {
    //     
    // }
}