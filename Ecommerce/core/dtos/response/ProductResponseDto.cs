using Ecommerce.core.Entities;
using Type = Ecommerce.core.Entities.Type;

namespace Ecommerce.core.dtos;

public class ProductResponseDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public bool IsVisible { get; set; }

    public Status? Status { get; set; }
    public Type? Type { get; set; }
}