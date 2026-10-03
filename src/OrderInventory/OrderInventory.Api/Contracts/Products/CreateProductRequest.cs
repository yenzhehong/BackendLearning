using System.ComponentModel.DataAnnotations;

namespace OrderInventory.Api.Contracts.Products;

public class CreateProductRequest
{
    [Required]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Sku { get; set; } = string.Empty;

    [Range(
        typeof(decimal),
        "0",
        "79228162514264337593543950335",
        MinimumIsExclusive = true,
        ParseLimitsInInvariantCulture = true,
        ErrorMessage = "Price must be greater than zero.")]
    public decimal Price { get; set; }
}