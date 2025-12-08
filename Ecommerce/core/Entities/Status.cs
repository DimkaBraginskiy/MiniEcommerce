using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.core.Entities;

[Table("Status")]
public class Status
{
    [Key] 
    public int Id { get; set; }
    [Required]
    [MaxLength(15)]
    public string? Name { get; set; }
}