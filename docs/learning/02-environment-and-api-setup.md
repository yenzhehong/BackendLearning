# Lesson 02 - Environment and API Setup

## Learning Objective

Understand the development environment and create a local controller-based ASP.NET Core API.

## Concepts

A repository holds project files and Git history. A solution organizes projects.
A C# project uses a .csproj file to describe its target framework and dependencies.
The repos folder is a conventional storage location, not a required application structure.
Cloning copies a remote repository and its history to a local checkout.

## Terminology

- SDK: development tools for building, running, and testing applications.
- Runtime: components needed to run applications.
- Workload: a group of development components; Visual Studio workloads and dotnet workloads are managed separately.
- LTS: Long Term Support.
- OpenAPI: a standard description of API operations, inputs, and responses.
- Launch profile: local startup settings, including addresses and environment.
- HTTPS: HTTP protected with TLS encryption.
- Port: identifies a network listening endpoint on a host.

## Tools

Visual Studio Community 2026, PowerShell, .NET SDK, Chrome, Git, and GitHub.

## Implementation

Environment check: `dotnet --info`.
Observed SDKs: 8.0.422 and 10.0.401; the command selected 10.0.401.
Observed ASP.NET Core runtimes: 8.0.28 and 10.0.12; Windows x64.
Visual Studio version: 18.10.3, with ASP.NET and web development installed.

The selected template is ASP.NET Core Web API, not the Native AOT template.
The solution is `src/OrderInventory/OrderInventory.slnx`.
The project is `src/OrderInventory/OrderInventory.Api/OrderInventory.Api.csproj`.

Template settings:

- Framework: .NET 10.
- Authentication: None.
- HTTPS, OpenAPI, and controllers enabled.
- Top-level statements retained.
- Container support and Aspire orchestration not enabled.

The HTTPS launch profile listens at https://localhost:7000 and http://localhost:5006.
These are two entry points for the same application, not two applications.
UseHttpsRedirection redirects HTTP requests to HTTPS; it does not encrypt the original HTTP request.
GET https://localhost:7000/weatherforecast returned five JSON weather records.

## Engineering Best Practices

- Keep source and documentation in the same repository.
- Ignore generated bin, obj, and .vs directories in Git.
- Keep real credentials out of committed configuration files.
- Select technologies for requirements and verify performance with measurements.

## Common Mistakes

- Assuming OpenAPI support automatically includes Swagger UI.
- Treating successful dependency restore as proof the application is running.
- Assuming Native AOT guarantees faster request processing for every workload.
- Confusing a repository with an individual .NET project.

## Interview Knowledge

### How do JIT and Native AOT differ?

JIT compiles intermediate code to machine code at runtime. Native AOT compiles to
native code during publishing, with compatibility constraints and potential startup
and memory benefits. Ordinary local execution of an AOT-configured project can still use JIT.

## What I Implemented

A local .NET 10 controller-based API skeleton with OpenAPI support. No database or business features.

## What I Learned

How the SDK, IDE, solution, project, launch profile, and browser request fit together.

## Review Checklist

- [x] Checked the environment and created the API project.
- [x] Ran the HTTPS profile and observed JSON.
- [ ] Explain the environment and template choices without notes.

## References

- [Create a controller-based API](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-10.0)
- [Native AOT support](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/native-aot?view=aspnetcore-10.0)
