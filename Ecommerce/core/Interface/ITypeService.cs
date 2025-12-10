using Ecommerce.core.dtos;
using Ecommerce.core.dtos.request;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.core.Interface;

public interface ITypeService
{
    public Task<IEnumerable<TypeResponseDto>> GetTypesAsync(CancellationToken token);
    public Task<TypeResponseDto> CreateTypeAsync(CancellationToken token, TypeRequestDto dto);
    public Task<bool> RemoveTypeAsync(CancellationToken token, string name);
}