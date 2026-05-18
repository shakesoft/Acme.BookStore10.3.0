using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.AuditLogging;
using Volo.Abp.Domain.Repositories;

public class RecentErrorsAppService : ApplicationService
{
    private readonly IRepository<AuditLog, Guid> _auditRepo;

    public RecentErrorsAppService(IRepository<AuditLog, Guid> auditRepo)
    {
        _auditRepo = auditRepo;
    }

    public async Task<List<ErrorDto>> GetAsync()
    {
        var query = await _auditRepo.GetQueryableAsync();

        var errors = await query
            .Where(x => x.Exceptions != null)
            .OrderByDescending(x => x.ExecutionTime)
            .Take(10)
            .ToListAsync();

        return errors.Select(x => new ErrorDto
        {
            Message = x.Exceptions,
            Url = x.Url,
            Time = x.ExecutionTime
        }).ToList();
    }
}