# .NET Backend Developer Learning Project

A hands-on learning project designed to develop professional .NET backend engineering skills through practical implementation, documentation, and interview preparation.

## Project

Order & Inventory Management System

## Main Goals

- Learn professional ASP.NET Core backend development
- Understand software architecture and engineering practices
- Design maintainable REST APIs
- Learn relational database design
- Understand database indexing and query optimization
- Learn Entity Framework Core
- Implement authentication and authorization
- Learn caching with Redis
- Understand transactions and concurrency
- Learn testing strategies
- Practice Agile software development
- Build professional technical documentation
- Prepare for mid-level and senior-level .NET backend interviews

## Learning Method

The project is developed incrementally.

Each topic will include:

- Concepts
- Terminology
- Practical implementation
- Engineering best practices
- Common mistakes
- Interview knowledge
- Documentation
- Review

## Technology Stack

- C# and .NET 10
- ASP.NET Core controller-based Web API
- Built-in OpenAPI document generation
- Visual Studio Community 2026
- Git and GitHub
- xUnit for unit testing

## Current Implementation

The application currently provides a weather sample API for learning routing,
JSON responses, debugging, and dependency injection. No database, authentication,
or order and inventory features have been implemented. A create-product request
DTO and its validation tests are prepared; no product endpoint exists yet.

The solution is located at `src/OrderInventory/OrderInventory.slnx`.
Open it in Visual Studio and select the `https` launch profile to run the API.
The current local endpoint is `https://localhost:7000/weatherforecast`.
Local ports are defined in the API project's `Properties/launchSettings.json`.

## Tests

`OrderInventory.Api.Tests` references the API project and tests the temperature
classification service independently of HTTP and database access.
Four cases cover both sides of the 10 C and 25 C boundaries.
Twelve additional cases verify create-product DTO validation: a valid request,
blank names and SKUs, string length boundaries, and non-positive and small positive prices.

Run them through Visual Studio's Test Explorer or from the repository root:

```powershell
dotnet test src/OrderInventory/OrderInventory.Api.Tests/OrderInventory.Api.Tests.csproj
```

Passing these tests verifies the covered business rules, not API throughput or database correctness.

## Development Methodology

Agile

## Documentation

Project documentation is located in the `/docs` directory.

- [Lesson 01: SDLC and Agile](docs/learning/01-sdlc-and-agile.md)
- [Lesson 02: Environment and API Setup](docs/learning/02-environment-and-api-setup.md)
- [Lesson 03: Routing, Debugging, and Dependency Injection](docs/learning/03-routing-debugging-and-di.md)
- [Lesson 04: Unit Testing and Boundary Regression](docs/learning/04-unit-testing-and-boundary-regression.md)
- [Lesson 05: Product Request DTO and Validation](docs/learning/05-product-request-dto-and-validation.md)
- [Technical Glossary](docs/project/glossary.md)
- [Progress Log](docs/progress/progress-log.md)
