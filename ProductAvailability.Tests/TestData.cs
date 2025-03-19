using ProductAvailability.DataAccess;
using ProductAvailability.Entities;

namespace ProductAvailability.Tests;

public static class TestData
{
    public static Guid customerUA = Guid.NewGuid();
    public static Guid customerDK = Guid.NewGuid();

    public static void SeedDatabase(ProductsDbContext dbContext)
    {
        dbContext.Products.AddRange(new[]
        {
            new Product
            {
                Name = "Word",
                IsAvailableByDefault = true,
                VersionByDefault = "1.0"
            },
            new Product
            {
                Name = "Excel",
                IsAvailableByDefault = true,
                VersionByDefault = "1.0",
                CountryOverrides = new List<CountryOverride>
                {
                    new CountryOverride
                    {
                        CountryCode = "UA",
                        IsAvailable = false
                    },
                    new CountryOverride
                    {
                        CountryCode = "US",
                        Version = "2.0b"
                    }
                }
            },
            new Product
            {
                Name = "PowerPoint",
                IsAvailableByDefault = false,
                VersionByDefault = "1.1",
                CountryOverrides = new List<CountryOverride>
                {
                    new CountryOverride
                    {
                        CountryCode = "DK",
                        IsAvailable = true,
                        Version = "1.6"
                    },
                    new CountryOverride
                    {
                        CountryCode = "FR",
                        IsAvailable = true
                    }
                },
                CustomerOverrides = new List<CustomerOverride>
                {
                    new CustomerOverride
                    {
                        CustomerId = customerDK,
                        Version = "1.8"
                    },
                    new CustomerOverride
                    {
                        CustomerId = customerUA
                    }
                }
            }
        });

        dbContext.SaveChanges();
    }
}