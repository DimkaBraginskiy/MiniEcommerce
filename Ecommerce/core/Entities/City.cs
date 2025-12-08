using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.core.Entities;

[Table("City")]
public class City
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(25)]
    public string? Name { get; set; }

    [ForeignKey("Country")] 
    public int CountryId;
    public Country? Country;
}