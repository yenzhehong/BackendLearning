using System.ComponentModel.DataAnnotations;
using OrderInventory.Api.Contracts.Products;
using Xunit;

namespace OrderInventory.Api.Tests;

public class CreateProductRequestTests
{
    [Fact]
    public void Validation_WhenRequestIsValid_ReturnsTrue()
    {
        // Arrange
        var request = new CreateProductRequest
        {
            Name = "Mechanical Keyboard",
            Sku = "KB-001",
            Price = 199.90m
        };

        var context = new ValidationContext(request);
        var errors = new List<ValidationResult>();

        // Act
        var isValid = Validator.TryValidateObject(
            request,
            context,
            errors,
            validateAllProperties: true);

        // Assert
        Assert.True(isValid);
        Assert.Empty(errors);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Validation_WhenNameIsBlank_ReturnsNameError(string name)
    {
        // Arrange
        var request = new CreateProductRequest
        {
            Name = name,
            Sku = "KB-001",
            Price = 199.90m
        };

        var errors = new List<ValidationResult>();

        // Act
        var isValid = Validator.TryValidateObject(
            request,
            new ValidationContext(request),
            errors,
            validateAllProperties: true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(
            errors,
            error => error.MemberNames.Contains(
                nameof(CreateProductRequest.Name)));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Validation_WhenPriceIsNonPositive_ReturnsPriceError(
    int price)
    {
        // Arrange
        var request = new CreateProductRequest
        {
            Name = "Mechanical Keyboard",
            Sku = "KB-001",
            Price = price
        };

        var errors = new List<ValidationResult>();

        // Act
        var isValid = Validator.TryValidateObject(
            request,
            new ValidationContext(request),
            errors,
            validateAllProperties: true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(
            errors,
            error => error.MemberNames.Contains(
                nameof(CreateProductRequest.Price)));
    }

    [Fact]
    public void Validation_WhenPriceIsSmallPositiveDecimal_ReturnsTrue()
    {
        // Arrange
        var request = new CreateProductRequest
        {
            Name = "Mechanical Keyboard",
            Sku = "KB-001",
            Price = 0.001m
        };

        var errors = new List<ValidationResult>();

        // Act
        var isValid = Validator.TryValidateObject(
            request,
            new ValidationContext(request),
            errors,
            validateAllProperties: true);

        // Assert
        Assert.True(isValid);
        Assert.Empty(errors);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Validation_WhenSkuIsBlank_ReturnsSkuError(string sku)
    {
        // Arrange
        var request = new CreateProductRequest
        {
            Name = "Mechanical Keyboard",
            Sku = sku,
            Price = 199.90m
        };

        var errors = new List<ValidationResult>();

        // Act
        var isValid = Validator.TryValidateObject(
            request,
            new ValidationContext(request),
            errors,
            validateAllProperties: true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(
            errors,
            error => error.MemberNames.Contains(
                nameof(CreateProductRequest.Sku)));
    }

    [Theory]
    [InlineData(200, true)]
    [InlineData(201, false)]
    public void Validation_WhenNameLengthIsAtBoundary_ReturnsExpectedResult(
    int length,
    bool expectedValid)
    {
        // Arrange
        var request = new CreateProductRequest
        {
            Name = new string('A', length),
            Sku = "KB-001",
            Price = 199.90m
        };

        var errors = new List<ValidationResult>();

        // Act
        var isValid = Validator.TryValidateObject(
            request,
            new ValidationContext(request),
            errors,
            validateAllProperties: true);

        // Assert
        Assert.Equal(expectedValid, isValid);

        if (expectedValid)
        {
            Assert.Empty(errors);
        }
        else
        {
            Assert.Contains(
                errors,
                error => error.MemberNames.Contains(
                    nameof(CreateProductRequest.Name)));
        }
    }

    [Theory]
    [InlineData(50, true)]
    [InlineData(51, false)]
    public void Validation_WhenSkuLengthIsAtBoundary_ReturnsExpectedResult(
    int length,
    bool expectedValid)
    {
        // Arrange
        var request = new CreateProductRequest
        {
            Name = "Mechanical Keyboard",
            Sku = new string('A', length),
            Price = 199.90m
        };

        var errors = new List<ValidationResult>();

        // Act
        var isValid = Validator.TryValidateObject(
            request,
            new ValidationContext(request),
            errors,
            validateAllProperties: true);

        // Assert
        Assert.Equal(expectedValid, isValid);

        if (expectedValid)
        {
            Assert.Empty(errors);
        }
        else
        {
            Assert.Contains(
                errors,
                error => error.MemberNames.Contains(
                    nameof(CreateProductRequest.Sku)));
        }
    }
}