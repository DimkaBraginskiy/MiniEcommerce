using Ecommerce.core.dtos;
using Ecommerce.core.dtos.request;

namespace Ecommerce.core.Interface;

public interface IProductService
{
    public Task<IEnumerable<ProductResponseDto>> GetProductsAsync(CancellationToken token);
    public Task<ProductResponseDto> CreateProductAsync(CancellationToken token, ProductRequestDto dto);
}