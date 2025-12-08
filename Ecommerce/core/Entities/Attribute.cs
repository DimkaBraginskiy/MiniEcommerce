using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.core.Entities;

[Table("Attribute")]
public class Attribute
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(25)]
    public string? Name { get; set; }
    public AttributeDataType DataType { get; set; }

    public ICollection<Type> Types = new List<Type>();
}