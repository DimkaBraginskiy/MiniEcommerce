using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.core.Entities;

[Table("Warehouse")]
public class Warehouse
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(25)]
    public string? Name { get; set; }
    
    [ForeignKey("Country")]
    public int CountryId { get; set; }
    public Country? Country { get; set; }

    public IEnumerable<Product> Products = new List<Product>();
}