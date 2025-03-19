using Microsoft.EntityFrameworkCore;
using ProductAvailability.Entities;

namespace ProductAvailability.DataAccess;

public class ProductsDbContext : DbContext
{
    public ProductsDbContext(DbContextOptions<ProductsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();

    public DbSet<CountryOverride> CountryOverrides => Set<CountryOverride>();

    public DbSet<CustomerOverride> CustomerOverrides => Set<CustomerOverride>();
}