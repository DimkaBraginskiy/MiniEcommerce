using Ecommerce.core.Entities;

namespace Ecommerce.core.Interface;

public interface IProductRepository
{
    public Task<IEnumerable<Product>> GetProductsAsync(CancellationToken token);
    public Task<Product> CreateProductAsync(CancellationToken token, Product product);
}