using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ProductAvailability.ApplicationServices;
using ProductAvailability.DataAccess;
using ProductAvailability.Dtos;

namespace ProductAvailability.Tests;

public class ProductsServiceTests
{
    private readonly ProductsService _productsService;

    public ProductsServiceTests()
    {
        var contextOptions = new DbContextOptionsBuilder<ProductsDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString());
        var dbContext = new ProductsDbContext(contextOptions.Options);
        _productsService = new ProductsService(dbContext);

        TestData.SeedDatabase(dbContext);
    }

    [Fact]
    public async Task Returns_defaults_if_no_overrides()
    {
        // Arrange
        var request = new GetProductsRequest
        {
            CustomerId = Guid.NewGuid(),
            CountryCode = "DE"
        };

        var expectedResponse = new GetProductsResponse
        {
            Products = new List<ProductDto>
            {
                new ProductDto { Name = "Word", IsAvailable = true, Version = "1.0" },
                new ProductDto { Name = "Excel", IsAvailable = true, Version = "1.0" },
                new ProductDto { Name = "PowerPoint", IsAvailable = false, Version = "1.1" }
            }
        };

        // Act
        var response = await _productsService.GetProductsAsync(request, default);

        // Assert
        response.Should().BeEquivalentTo(expectedResponse);
    }

    [Fact]
    public async Task Ignores_null_overrides()
    {
        // Arrange
        var request = new GetProductsRequest
        {
            CustomerId = TestData.customerUA,
            CountryCode = "UA"
        };

        var expectedResponse = new GetProductsResponse
        {
            Products = new List<ProductDto>
            {
                new ProductDto { Name = "Word", IsAvailable = true, Version = "1.0" },
                new ProductDto { Name = "Excel", IsAvailable = false, Version = "1.0" },
                new ProductDto { Name = "PowerPoint", IsAvailable = false, Version = "1.1" }
            }
        };

        // Act
        var response = await _productsService.GetProductsAsync(request, default);

        // Assert
        response.Should().BeEquivalentTo(expectedResponse);
    }

    [Fact]
    public async Task Proper_overrides_priorities()
    {
        // Arrange
        var request = new GetProductsRequest
        {
            CustomerId = TestData.customerDK,
            CountryCode = "DK"
        };

        var expectedResponse = new GetProductsResponse
        {
            Products = new List<ProductDto>
            {
                new ProductDto { Name = "Word", IsAvailable = true, Version = "1.0" },
                new ProductDto { Name = "Excel", IsAvailable = true, Version = "1.0" },
                new ProductDto { Name = "PowerPoint", IsAvailable = true, Version = "1.8" }
            }
        };

        // Act
        var response = await _productsService.GetProductsAsync(request, default);

        // Assert
        response.Should().BeEquivalentTo(expectedResponse);
    }
}