using OrderInventory.Api.Models;
using OrderInventory.Api.Repositories;
using Xunit;

namespace OrderInventory.Api.Tests;

public class InMemoryProductRepositoryTests
{
    [Fact]
    public void Add_WhenIdAlreadyExists_ReturnsFalseAndKeepsOriginal()
    {
        // Arrange
        var repository = new InMemoryProductRepository();
        var id = Guid.NewGuid();

        var original = new Product
        {
            Id = id,
            Name = "Original Keyboard",
            Sku = "KB-001",
            Price = 199.90m
        };

        var duplicate = new Product
        {
            Id = id,
            Name = "Replacement Keyboard",
            Sku = "KB-002",
            Price = 299.90m
        };

        // Act
        var firstAdded = repository.Add(original);
        var secondAdded = repository.Add(duplicate);
        var stored = repository.GetById(id);

        // Assert
        Assert.True(firstAdded);
        Assert.False(secondAdded);
        Assert.Same(original, stored);
    }
}