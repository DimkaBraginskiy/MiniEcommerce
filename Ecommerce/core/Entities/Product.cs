using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Ecommerce.core.Entities;

[Table("Product")]
public class Product
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(25)]
    public string? Name { get; set; }
    [MaxLength(100)]
    public string? Description { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public bool IsVisible { get; set; }

    [ForeignKey("Status")]
    public int StatusId { get; set; }
    public Status? Status { get; set; }
    
    [ForeignKey("Type")]
    public int TypeId { get; set; }
    public Type? Type { get; set; }

    public ICollection<Warehouse> Warehouses = new List<Warehouse>();
}