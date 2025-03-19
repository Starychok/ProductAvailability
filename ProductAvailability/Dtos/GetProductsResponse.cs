namespace ProductAvailability.Dtos;

public class GetProductsResponse
{
    public List<ProductDto> Products { get; set; } = new List<ProductDto>();
}