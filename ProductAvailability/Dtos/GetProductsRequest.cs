using System.ComponentModel.DataAnnotations;

namespace ProductAvailability.Dtos;

public class GetProductsRequest
{
    [Required]
    public Guid CustomerId { get; set; }

    [Required]
    public string? CountryCode { get; set; }
}