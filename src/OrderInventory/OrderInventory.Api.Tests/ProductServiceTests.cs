using OrderInventory.Api.Contracts.Products;
using OrderInventory.Api.Repositories;
using OrderInventory.Api.Services;
using Xunit;

namespace OrderInventory.Api.Tests;

public class ProductServiceTests
{
    [Fact]
    public void Create_WhenRequestIsValid_ProductCanBeRetrieved()
    {
        // Arrange
        var repository = new InMemoryProductRepository();
        var service = new ProductService(repository);

        var request = new CreateProductRequest
        {
            Name = "Mechanical Keyboard",
            Sku = "KB-001",
            Price = 199.90m
        };

        // Act
        var created = service.Create(request);
        var retrieved = service.GetById(created.Id);

        // Assert
        Assert.NotEqual(Guid.Empty, created.Id);
        Assert.NotNull(retrieved);
        Assert.Equal(created.Id, retrieved.Id);
        Assert.Equal(request.Name, retrieved.Name);
        Assert.Equal(request.Sku, retrieved.Sku);
        Assert.Equal(request.Price, retrieved.Price);
    }

    [Fact]
    public void GetById_WhenProductDoesNotExist_ReturnsNull()
    {
        // Arrange
        var repository = new InMemoryProductRepository();
        var service = new ProductService(repository);

        // Act
        var result = service.GetById(Guid.NewGuid());

        // Assert
        Assert.Null(result);
    }
}