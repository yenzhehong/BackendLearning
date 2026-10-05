using OrderInventory.Api.Contracts.Products;
using OrderInventory.Api.Models;
using OrderInventory.Api.Repositories;

namespace OrderInventory.Api.Services;

public class ProductService
{
    private readonly InMemoryProductRepository _repository;

    public ProductService(InMemoryProductRepository repository)
    {
        _repository = repository;
    }

    public Product Create(CreateProductRequest request)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Sku = request.Sku,
            Price = request.Price
        };

        var added = _repository.Add(product);

        if (!added)
        {
            throw new InvalidOperationException(
                "A product with the same ID already exists.");
        }

        return product;
    }

    public Product? GetById(Guid id)
    {
        return _repository.GetById(id);
    }
}