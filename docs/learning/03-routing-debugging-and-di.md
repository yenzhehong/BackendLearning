# Lesson 03 - Routing, Debugging, and Dependency Injection

## Learning Objective

Trace a request into a controller, inspect its data, and use an injected business service.

## Concepts

`[Route("[controller]")]` substitutes the controller class name without its Controller suffix.
WeatherForecastController therefore maps to WeatherForecast; matching accepts the lowercase path.
The token is based on the class name, not the file or action method name.
`[HttpGet]` restricts the action to GET. Its Name property names the endpoint for link generation;
it does not define the URL. An action route normally combines with the controller route.
During the experiment, `[Route("")]` with an empty GET action route mapped to the root path.
The controller route was then restored.

JSON serialization converts returned objects into response data.
The default Web JSON naming policy turns TemperatureC into temperatureC.

## Terminology

- Class: a type definition; object: an instance of a type.
- Property: a member exposing data; TemperatureF is computed from TemperatureC.
- Nullable reference: string? permits null; null differs from an empty string.
- LINQ: language-integrated query operations on sequences.
- Lambda: an anonymous function, such as the transformation supplied to Select.
- Deferred execution: processing starts when a sequence is enumerated.
- Breakpoint: a place where a debugger pauses execution.
- DI: Dependency Injection, supplying a class with the components it needs.
- Constructor injection: receiving a dependency through a constructor parameter.
- Scoped lifetime: one service instance per scope; normally one scope per Web request.

## Tools

Visual Studio debugger, DataTips, IEnumerable Visualizer, and Chrome Network panel.

## Implementation

Enumerable.Range(1, 5) produces five integers starting at one.
Select transforms each into a weather object; ToArray enumerates the sequence immediately.
Random.Shared.Next(-20, 55) includes -20 and excludes 55.
The local forecasts variable makes the generated array easier to inspect.

Set a breakpoint at `return forecasts;`, request the API, inspect the array, and
continue with F5. Compare the JSON from that same request, without refreshing again.
Debugger pause time is not a production latency measurement.

Program.cs registers the service before Build:

```csharp
builder.Services.AddScoped<WeatherSummaryService>();
```

AddControllers registers framework services; MapControllers maps controller endpoints.
The controller constructor receives WeatherSummaryService and stores its reference in a readonly field.
Readonly restricts field reassignment; it does not make the referenced object immutable.

For each forecast, generate the temperature once and pass the same value to GetSummary:

- Below 10 C: Cold.
- From 10 C to below 25 C: Mild.
- At least 25 C: Hot.

No interface was added because this exercise does not yet require one.
The service is an in-process class, not a separately deployed microservice.

## Engineering Best Practices

- Keep business rules in a focused component when it improves clarity and testability.
- Choose a service lifetime based on its state and dependencies, not as a speed switch.
- Test boundary values and business correctness independently of HTTP handling.
- Verify response status as well as response content.
- Remove obsolete commented-out code; Git retains previous committed versions.

## Common Mistakes

- Comparing debugger data to a response from a different random-data request.
- Forgetting service registration before injecting it.
- Generating a second random temperature when selecting the summary.
- Confusing 400 Bad Request with 405 Method Not Allowed.

## Interview Knowledge

### What does constructor injection achieve?

It makes a class's dependencies explicit and allows the container to supply them.
The controller uses a supplied service instead of constructing it internally.

### Does a scoped registration create every registered service on each request?

No. A service is normally created when resolved and then reused within that scope.

## What I Implemented

A scoped WeatherSummaryService, constructor injection, and consistent temperature descriptions.

## What I Learned

The request travels through routing to an action, which calls the service and returns
objects that ASP.NET Core serializes into JSON. Debugging makes that flow observable.

## Review Checklist

- [x] Inspected forecasts and matched them to an HTTP response.
- [x] Observed HTTP 200 and application/json.
- [x] Registered, injected, and called a service.
- [x] Observed correct summary classifications in sample responses.
- [x] Test 9, 10, 24, and 25 C with automated tests (completed in Lesson 04).
- [ ] Explain DI and scoped lifetime without notes.

## References

- [Controller-based APIs](https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-10.0)
