namespace ProductAvailability.Entities;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;

    public bool IsAvailableByDefault { get; set; }

    public string VersionByDefault { get; set; } = default!;

    public List<CountryOverride> CountryOverrides { get; set; } = new List<CountryOverride>();

    public List<CustomerOverride> CustomerOverrides { get; set; } = new List<CustomerOverride>();
}