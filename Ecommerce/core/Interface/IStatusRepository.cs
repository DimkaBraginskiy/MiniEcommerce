using Ecommerce.core.Entities;

namespace Ecommerce.core.Interface;

public interface IStatusRepository
{
    public Task<bool> IsStatusAlreadyPresentAsync(CancellationToken token, Status status);
    public Task<IEnumerable<Status>> GetStatusesAsync(CancellationToken token);
    public Task<Status> CreateStatusAsync(CancellationToken token, Status status);
    public Task<int> RemoveStatusAsync(CancellationToken token, string name);
    public  Task<Status> GetStatusByIdAsync(CancellationToken token, int id);
    public  Task<Status> GetStatusByNameAsync(CancellationToken token, string name);
}