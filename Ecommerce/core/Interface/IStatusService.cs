using Ecommerce.core.dtos;
using Ecommerce.core.dtos.request;

namespace Ecommerce.core.Interface;

public interface IStatusService
{
    public Task<IEnumerable<StatusResponseDto>> GetStatusesAsync(CancellationToken token);
    public Task<StatusResponseDto> CreateStatusAsync(CancellationToken token, StatusRequestDto dto);
    public Task<bool> RemoveStatusAsync(CancellationToken token, string name);
}