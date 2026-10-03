# Lesson 05 - Product Request DTO and Validation

## Learning Objective

Define a controlled API input contract and verify its validation independently of HTTP and storage.

## Concepts

CreateProductRequest is a request DTO, not a database entity. It exposes Name, Sku,
and Price; the client does not supply a server-generated product identifier.
Contracts/Products is a code organization convention, not a framework requirement.
SKU is a business identifier and is distinct from a database primary key.

## Terminology

- DTO: Data Transfer Object.
- Data Annotations: attributes declaring validation rules.
- ValidationContext: context for validating an object.
- ValidationResult: a validation error, including associated member names.
- Exclusive minimum: a lower bound whose exact value is rejected.
- Invariant culture: a fixed parsing convention independent of server regional settings.

## Tools

C#, System.ComponentModel.DataAnnotations, xUnit, and Visual Studio Test Explorer.
No additional validation package was installed for this DTO exercise.

## Implementation

```csharp
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
```

Required rejects null, empty, and whitespace-only strings. string.Empty provides
an initial value; it does not make the request valid. StringLength measures .NET
string length, not encoded database bytes or necessarily user-perceived characters.
The current limits are provisional contract choices to align with later database design.

Price is validated as decimal, from an exclusive zero lower bound to decimal.MaxValue.
The upper bound is the type limit, not an agreed business price maximum.
The m literal suffix denotes decimal, for example 199.90m and 0.001m.
Omitting Price leaves zero on this DTO; handling of missing JSON fields is not tested here.

### Executing Validation in Tests

Constructing or assigning the DTO does not automatically run validation.
The tests explicitly call:

```csharp
var errors = new List<ValidationResult>();
var isValid = Validator.TryValidateObject(
    request,
    new ValidationContext(request),
    errors,
    validateAllProperties: true);
```

For invalid-field cases, other fields remain valid. Tests assert both false and
an error mentioning the intended property using nameof(CreateProductRequest.Name),
Sku, or Price. Valid cases assert true and an empty error collection.

### Covered Cases

- Valid Name, Sku, and Price 199.90: accepted.
- Name empty or whitespace-only: rejected with a Name error (two cases).
- Sku empty or whitespace-only: rejected with a Sku error (two cases).
- Name lengths 200 and 201: accepted and rejected respectively.
- Sku lengths 50 and 51: accepted and rejected respectively.
- Prices 0 and -1: rejected with a Price error (two cases).
- Price 0.001: accepted under the current positive-only rule.

These twelve DTO cases plus four weather cases produce sixteen tests.
new string('A', length) constructs deterministic boundary inputs.
Passing invalid-input tests means rejection worked, not that the input was accepted.

## Engineering Best Practices

- Define requirements before implementing persistence or endpoints.
- Restrict client-writable fields through an explicit request contract.
- Verify exact limits and the first invalid value.
- Associate expected errors with the correct field.
- Decide currency, decimal places, rounding, and maximum price before storing monetary data.
- Protect SKU uniqueness with a database constraint, not only a pre-insert existence query.
- Do not claim HTTP, database, or capacity guarantees from DTO unit tests.

## Common Mistakes

- Assuming get/set or string.Empty validates input.
- Assuming positive price means a minimum of one or two decimal places.
- Treating Required as SKU uniqueness enforcement.
- Rounding client prices silently without an agreed rule.
- Assuming a passing DTO test proves an API returns HTTP 400.

## Interview Knowledge

### Why separate a request DTO from a database entity?

It makes allowed input explicit and avoids coupling the API contract directly to
internal persistence fields. It helps prevent unintended client modification of those fields.

### What remains after request validation?

Business rules, authorization, persistence constraints, concurrent correctness,
HTTP response behavior, and operational performance still need implementation and verification.

## What I Implemented

A create-product DTO and twelve validation cases. No product endpoint or database was created.

## What I Learned

How to declare and execute validation, inspect member-specific errors, and test boundaries.

## Review Checklist

- [x] Defined Name, Sku, and Price input fields.
- [x] Verified required fields, length boundaries, and positive prices.
- [x] Observed sixteen passing tests including existing weather tests.
- [ ] Verify API validation responses through HTTP.
- [ ] Agree currency, price scale, maximum, and SKU normalization rules.
- [ ] Enforce and test persistent SKU uniqueness under concurrent requests.
