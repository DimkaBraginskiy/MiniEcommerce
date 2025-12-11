using Ecommerce.core.Entities;
using Ecommerce.core.Interface;
using Ecommerce.infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.infrastructure.Repository;

public class ProductRepository : IProductRepository
{
    private readonly EcommerceDbContext _dbContext;

    public ProductRepository(EcommerceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync(CancellationToken token)
    {
        var products =
            await _dbContext.Products
                .ToListAsync(token);

        return products;
    }

    public async Task<Product> CreateProductAsync(CancellationToken token, Product product)
    {
        await _dbContext.Products.AddAsync(product, token);

        await _dbContext.SaveChangesAsync(token);

        var res =
            await _dbContext.Products
                .Where(p => p.Name == product.Name)
                .FirstOrDefaultAsync(token);

        return res;
    }
}