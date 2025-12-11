namespace Ecommerce.core.dtos.request;

public class ProductRequestDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public bool IsVisible { get; set; }
    
    public string? StatusName { get; set; }
    public string? TypeName { get; set; }
}