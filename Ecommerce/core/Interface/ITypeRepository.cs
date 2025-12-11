using Microsoft.AspNetCore.Mvc;
using Type = Ecommerce.core.Entities.Type;

namespace Ecommerce.core.Interface;

public interface ITypeRepository
{
    public Task<IEnumerable<Type>> GetTypesAsync(CancellationToken token);
    public Task<bool> IsTypeAlreadyPresentAsync(CancellationToken token, Type type);
    public Task<Type> CreateTypeAsync(CancellationToken token, Type type);
    public Task<int> RemoveTypeAsync(CancellationToken token, string name);
    public Task<Type> GetTypeByIdAsync(CancellationToken token, int id);
    public Task<Type> GetTypeByNameAsync(CancellationToken token, string name);
}