using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.AuditLogging;
using Volo.Abp.Domain.Repositories;

public class LiveLogsAppService : ApplicationService
{
    private readonly IRepository<AuditLog, Guid> _auditRepo;

    public LiveLogsAppService(IRepository<AuditLog, Guid> auditRepo)
    {
        _auditRepo = auditRepo;
    }

    public async Task<List<LiveLogDto>> GetLatestAsync()
    {
        var query = await _auditRepo.GetQueryableAsync();

        var logs = await query
            .Where(x => x.HttpMethod != null)
            .OrderByDescending(x => x.ExecutionTime)
            .Take(10)
            .ToListAsync();

        return logs.Select(x => new LiveLogDto
        {
            Action = x.HttpMethod + " " + x.Url,
            Time = x.ExecutionTime,
            Duration = x.ExecutionDuration
        }).ToList();
    }
}