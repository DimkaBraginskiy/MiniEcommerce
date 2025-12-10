using Ecommerce.core.Entities;

namespace Ecommerce.core.Interface;

public interface IStatusRepository
{
    public Task<bool> IsStatusAlreadyPresentAsync(CancellationToken token, Status status);
    public Task<IEnumerable<Status>> GetStatusesAsync(CancellationToken token);
    public Task<Status> CreateStatusAsync(CancellationToken token, Status status);
    public Task<int> RemoveStatusAsync(CancellationToken token, string name);
}