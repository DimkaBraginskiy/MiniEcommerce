// StatusRepository.cs
using Ecommerce.core.Interface;
using Ecommerce.infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Status = Ecommerce.core.Entities.Status;

namespace Ecommerce.infrastructure.Repository;

public class StatusRepository : IStatusRepository
{
    private readonly EcommerceDbContext _dbContext;

    public StatusRepository(EcommerceDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<bool> IsStatusAlreadyPresentAsync(CancellationToken token, Status status)
    {
        return await _dbContext.Statuses
            .AnyAsync(s => s.Name == status.Name, token);
    }

    
    public async Task<IEnumerable<Status>> GetStatusesAsync(CancellationToken token)
    {

        return await _dbContext.Statuses.ToListAsync(token);
    }


    public async Task<Status> CreateStatusAsync(CancellationToken token, Status status)
    {
        await _dbContext.Statuses.AddAsync(status, token);
        await _dbContext.SaveChangesAsync(token);
        return status;
    }


    public async Task<int> RemoveStatusAsync(CancellationToken token, string name)
    {
        var foundObj = await _dbContext.Statuses
            .Where(s => s.Name == name)
            .FirstOrDefaultAsync(token);

        if (foundObj == null)
        {
            return 0;
        }

        _dbContext.Statuses.Remove(foundObj);
        return await _dbContext.SaveChangesAsync(token);
    }
    
    public async Task<Status> GetStatusByIdAsync(CancellationToken token, int id)
    {
        var status =
            await _dbContext.Statuses
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync(token);

        return status;
    }

    public async Task<Status> GetStatusByNameAsync(CancellationToken token, string name)
    {
        var status =
            await _dbContext.Statuses
                .Where(s => s.Name == name)
                .FirstOrDefaultAsync(token);

        return status;
    }
}