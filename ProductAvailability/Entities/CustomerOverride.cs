namespace ProductAvailability.Entities;

public class CustomerOverride
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public Guid CustomerId { get; set; }

    public bool? IsAvailable { get; set; }

    public string? Version { get; set; }
}