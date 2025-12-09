using Ecommerce.core.Entities;
using Microsoft.EntityFrameworkCore;
using Attribute = Ecommerce.core.Entities.Attribute;
using Type = Ecommerce.core.Entities.Type;


namespace Ecommerce.infrastructure.Data;

public class EcommerceDbContext : DbContext
{
    public DbSet<Attribute> Attributes { get; set; } = null!;
    public DbSet<Attribute_Value> AttributeValues { get; set; } = null!;
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Status> Statuses { get; set; } = null!;
    public DbSet<Type> Types { get; set; } = null!;
    public DbSet<Warehouse> Warehouses { get; set; } = null!;

    protected EcommerceDbContext() { }

    public EcommerceDbContext(DbContextOptions options) : base(options) { }
}