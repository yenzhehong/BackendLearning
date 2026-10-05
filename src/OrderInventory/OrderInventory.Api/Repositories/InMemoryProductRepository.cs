using System.Collections.Concurrent;
using OrderInventory.Api.Models;

namespace OrderInventory.Api.Repositories;

public class InMemoryProductRepository
{
    private readonly ConcurrentDictionary<Guid, Product> _products = new();

    public bool Add(Product product)
    {
        return _products.TryAdd(product.Id, product);
    }

    public Product? GetById(Guid id)
    {
        return _products.TryGetValue(id, out var product)
            ? product
            : null;
    }
}