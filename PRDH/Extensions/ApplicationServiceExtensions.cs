using Microsoft.EntityFrameworkCore;
using PRDH.Data;
using PRDH.Domain.Repositories;
using PRDH.Domain.Repositories.Interfaces;
using PRDH.Domain.Services;
using PRDH.Domain.Services.Interfaces;

namespace PRDH.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });
        services.AddCors();
        
        #region Services
        services.AddTransient<IWorkerService, WorkerService>();
        #endregion
        
        #region Repositories
        services.AddTransient<IWorkerRepository, WorkerRepository>();
        #endregion

        return services;
    }
}