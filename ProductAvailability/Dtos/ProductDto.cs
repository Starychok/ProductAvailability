namespace ProductAvailability.Dtos;

public class ProductDto
{
    public string Name { get; set; } = default!;

    public bool IsAvailable { get; set; }

    public string Version { get; set; } = default!;
}