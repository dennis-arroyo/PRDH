using Microsoft.AspNetCore.Mvc;
using PRDH.Domain.Repositories.Interfaces;
using PRDH.Domain.Services.Interfaces;
using PRDH.Entities;

namespace PRDH.Domain.Services;

public class WorkerService : IWorkerService
{

    private const string PRDH_API_URI = "https://biostatistics.salud.pr.gov";
    private readonly IWorkerRepository _workerRepository;

    public WorkerService(IWorkerRepository workerRepository)
    {
        _workerRepository = workerRepository;
    }

    public async Task<List<Order>> GetOrderTests(string orderTestId, string orderTestCategory, string orderTestType,
        DateTime sampleCollectedStartDate, DateTime sampleCollectedEndDate, DateTime createdAtStartDate,
        DateTime createdAtEndDate)
    {
        var httpClient = new HttpClient();
        var endpoint = "orders/tests/covid-19/minimal";
        
        // Create a UriBuilder and add query parameters
        var uriBuilder = new UriBuilder($"{PRDH_API_URI}/{endpoint}");
        var query = new List<string>();
        
        if (!string.IsNullOrEmpty(orderTestId))
        {
            query.Add($"OrderTestId={Uri.EscapeDataString(orderTestId)}");
        }
        else
        {
            query.Add($"OrderTestId={Uri.EscapeDataString("")}");
        }

        if (!string.IsNullOrWhiteSpace(orderTestCategory))
        {
            query.Add($"OrderTestCategory={Uri.EscapeDataString(orderTestCategory)}");
        }
        
        if (!string.IsNullOrWhiteSpace(orderTestType))
        {
            query.Add($"OrderTestType={Uri.EscapeDataString(orderTestType)}");
        }
        
        if (sampleCollectedStartDate != DateTime.MinValue)
        {
            query.Add($"SampleCollectedStartDate={sampleCollectedStartDate:o}");
        }
        
        if (sampleCollectedEndDate != DateTime.MinValue)
        {
            query.Add($"SampleCollectedEndDate={sampleCollectedEndDate:o}");
        }
        
        if (createdAtStartDate != DateTime.MinValue)
        {
            query.Add($"CreatedAtStartDate={createdAtStartDate:o}");
        }
        
        if (createdAtEndDate != DateTime.MinValue)
        {
            query.Add($"CreatedAtEndDate={createdAtEndDate:o}");
        }
        
        uriBuilder.Query = string.Join("&", query);
        
        HttpResponseMessage response = await httpClient.GetAsync(uriBuilder.Uri);
        return response.IsSuccessStatusCode switch
        {
            true => await response.Content.ReadFromJsonAsync<List<Order>>() ?? throw new InvalidOperationException(),
            _ => throw new HttpRequestException($"API request failed with status code: {response.StatusCode}")
        };
    }
}