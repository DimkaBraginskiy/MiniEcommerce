using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.core.Entities;

[Table("Attribute_Value")]
public class Attribute_Value
{
    [Key]
    public int Id { get; set; }
    
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    
    [ForeignKey("Attribute")]
    public int AttributeId { get; set; }
    public Attribute? Attribute { get; set; }
    
    [Required]
    public string? Value { get; set; }
}