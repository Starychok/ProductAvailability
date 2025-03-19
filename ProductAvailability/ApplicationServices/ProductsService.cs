using ProductAvailability.DataAccess;
using ProductAvailability.Dtos;

namespace ProductAvailability.ApplicationServices;

public class ProductsService
{
    private readonly ProductsDbContext _dbContext;

    public ProductsService(ProductsDbContext dbContext)
        => _dbContext = dbContext;

    /// <summary>
    /// Returns list of ALL Products with availability flag and allowed version,
    /// considering countries and personal customers overrides.
    /// Override priority (from highest to lowest): Customer => Country => Product default
    /// </summary>
    public Task<GetProductsResponse> GetProductsAsync(
        GetProductsRequest request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}