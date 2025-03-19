namespace ProductAvailability.Entities;

public class CountryOverride
{
    public int Id { get; set; }
    
    public int ProductId { get; set; }

    public string CountryCode { get; set; } = default!;

    public bool? IsAvailable { get; set; }

    public string? Version { get; set; }
}