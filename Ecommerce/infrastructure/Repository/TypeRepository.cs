using Ecommerce.core.Interface;
using Ecommerce.infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Type = Ecommerce.core.Entities.Type;

namespace Ecommerce.infrastructure.Repository;

public class TypeRepository : ITypeRepository
{
    private readonly EcommerceDbContext _dbContext;

    public TypeRepository(EcommerceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> IsTypeAlreadyPresentAsync(CancellationToken token, Type type)
    {
        var typeRes = await
            _dbContext.Types
                .Where(t =>  t.Name == type.Name  )
                .FirstOrDefaultAsync(token);

        return typeRes != null;
    }

    public async Task<IEnumerable<Type>> GetTypesAsync(CancellationToken token)
    {
        var types =
            await _dbContext.Types
                .ToListAsync(token);

        if (types.Count == 0)
        {
            Console.WriteLine("oh hi actually");
            throw new ArgumentException("Types size is empty.");
        }

        return types;
    }

    public async Task<Type> CreateTypeAsync(CancellationToken token, Type type)
    {
        await _dbContext.Types.AddAsync(type, token);
        
        await _dbContext.SaveChangesAsync(token);

        var res = await _dbContext.Types
            .Where(t => t.Name == type.Name)
            .FirstOrDefaultAsync(token);
        
        
        return res;
    }

    public async Task<int> RemoveTypeAsync(CancellationToken token, string name)
    {
        var foundObj =
            await _dbContext.Types
                .Where(t => t.Name == name)
                .FirstOrDefaultAsync(token);

        if (foundObj == null)
        {
            return 0;
        }

        _dbContext.Types
            .Remove(foundObj);

        return await _dbContext.SaveChangesAsync(token);
    }
}