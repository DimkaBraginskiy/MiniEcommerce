using System.Collections;
using Ecommerce.core.dtos;
using Ecommerce.core.dtos.request;
using Ecommerce.core.Entities;
using Ecommerce.core.Interface;

namespace Ecommerce.core.Service;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ITypeRepository _typeRepository;
    private readonly IStatusRepository _statusRepository;

    public ProductService(IProductRepository productRepository, ITypeRepository typeRepository, IStatusRepository statusRepository)
    {
        _productRepository = productRepository;
        _typeRepository = typeRepository;
        _statusRepository = statusRepository;
    }

    public async Task<IEnumerable<ProductResponseDto>> GetProductsAsync(CancellationToken token)
    {
        var productEntities = await _productRepository.GetProductsAsync(token);

        if (productEntities.Count() == 0)
        {
            return new List<ProductResponseDto>();
        }

        var productDtos = new List<ProductResponseDto>();
        
        foreach (var product in productEntities)
        {
            var type = await _typeRepository.GetTypeByIdAsync(token, product.TypeId);
            var status = await _statusRepository.GetStatusByIdAsync(token, product.StatusId);

            var productDto = new ProductResponseDto()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                IsVisible = product.IsVisible,
                Status = status,
                Type = type
            };
            
            productDtos.Add(productDto);
        }

        return productDtos;
    }

    public async Task<ProductResponseDto> CreateProductAsync(CancellationToken token, ProductRequestDto dto)
    {
        Console.WriteLine("Checking dto");
        if (dto.Equals(null))
        {
            throw new ArgumentException("Dto provided has a value of null");
        }

        Console.WriteLine("Checking name");
        if (dto.Name.Equals(null) || dto.Name.Length == 0)
        {
            throw new ArgumentException("Name can not be null or empty");
        }
        
        Console.WriteLine("Checking desc");
        if (dto.Description.Equals(null) || dto.Description.Length == 0)
        {
            throw new ArgumentException("Description can not be null or empty");
        }

        Console.WriteLine("Checking price");
        if (dto.Price.Equals(null) || dto.Price <= 0)
        {
            throw new ArgumentException("Price can not be null and can not be <= 0");
        }

        Console.WriteLine("Checking visibility");
        if (dto.IsVisible.Equals(null))
        {
            throw new ArgumentException("Visibility field can not be empty");
        }

        
        var productStatus = await _statusRepository.GetStatusByNameAsync(token, dto.StatusName);
        var productType = await _typeRepository.GetTypeByNameAsync(token, dto.TypeName);
        
        Console.WriteLine("Checking product status");
        if (productStatus == null)
        {
            throw new ArgumentException($"Provided status name {dto.StatusName} does not exist");
        }
        
        Console.WriteLine("Checking product type");
        if (productType == null)
        {
            throw new ArgumentException($"Provided type name {dto.TypeName} does not exist");
        }

        
        

        var productObj = new Product()
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            IsVisible = dto.IsVisible,
            
            StatusId = productStatus.Id,
            Status = productStatus,
            
            TypeId = productType.Id,
            Type = productType
        };

        var res = await _productRepository.CreateProductAsync(token, productObj);

        return new ProductResponseDto()
        {
            Name = productObj.Name,
            Description = productObj.Description,
            Price = productObj.Price,
            IsVisible = productObj.IsVisible,
            
            Status = productStatus,
            Type = productType
        };
    }
}