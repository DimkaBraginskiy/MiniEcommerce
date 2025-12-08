using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.core.Entities;

[Table("Country")]
public class Country
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(25)]
    public string? Name { get; set; }

    public ICollection<City> Cities = new List<City>();
}