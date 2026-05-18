using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Web.Components.SystemHealth;

public class SystemHealthAppService : ApplicationService
{
    private readonly HealthCheckService _healthCheckService;

    public SystemHealthAppService(HealthCheckService healthCheckService)
    {
        _healthCheckService = healthCheckService;
    }

    public async Task<SystemHealthDto> GetAsync()
    {
        var report = await _healthCheckService.CheckHealthAsync();

        var dbStatus = report.Entries
            .Where(x => x.Key.Contains("Database"))
            .Select(x => x.Value.Status.ToString())
            .FirstOrDefault() ?? "Unknown";

        return new SystemHealthDto
        {
            Status = report.Status.ToString(),
            DbStatus = dbStatus,
            Duration = report.TotalDuration.TotalMilliseconds
        };
    }
}