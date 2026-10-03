# Lesson 04 - Unit Testing and Boundary Regression

## Learning Objective

Write repeatable tests for business boundaries, read failures, and verify a repair.

## Concepts

A unit test checks a small unit of behavior. This exercise calls WeatherSummaryService
directly; it does not start the API or connect to a database.
API testing through a browser or Postman operates at a different boundary.
Integration tests, concurrency tests, and load tests address additional risks.

The business rule is:

- Below 10 C: Cold.
- From 10 C to below 25 C: Mild.
- At least 25 C: Hot.

Test values 9, 10, 24, and 25 check both sides of the two transition points.
Expected values come from the rule, not from whatever the implementation returns.

## Terminology

- Unit test: an automated check of a small unit of behavior.
- Assertion: a check that actual behavior matches an expectation.
- Fact: an xUnit test without supplied case data.
- Theory: an xUnit test run with supplied case data.
- InlineData: one set of arguments for a Theory.
- Regression: a code change that breaks previously correct behavior.
- AAA: Arrange, Act, Assert.

## Tools

Visual Studio Test Explorer and xUnit 2.9.3.
The project also contains the template's test SDK, Visual Studio runner, and
coverlet collector. Coverage collection was not practiced in this lesson.

## Implementation

Created OrderInventory.Api.Tests beside the API project in the existing solution.
Both projects target net10.0. The test project references the API project, allowing
it to use the public WeatherSummaryService class. The API does not reference tests.

Initially used Fact to verify 10 C returns Mild, then replaced it with:

```csharp
using OrderInventory.Api.Services;
using Xunit;

namespace OrderInventory.Api.Tests;

public class WeatherSummaryServiceTests
{
    [Theory]
    [InlineData(9, "Cold")]
    [InlineData(10, "Mild")]
    [InlineData(24, "Mild")]
    [InlineData(25, "Hot")]
    public void GetSummary_WhenGivenTemperature_ReturnsExpectedSummary(
        int temperatureC,
        string expectedSummary)
    {
        // Arrange
        var service = new WeatherSummaryService();

        // Act
        var result = service.GetSummary(temperatureC);

        // Assert
        Assert.Equal(expectedSummary, result);
    }
}
```

Constructing the service directly isolates its rule from the DI container.
Assert.Equal receives the expected value first and the actual value second.

### Running and Inspecting Tests

Open Test > Test Explorer and select Run All Tests.
Expand the Theory to inspect individual cases. Widen the Test column to see the
temperatureC and expectedSummary arguments. Display order need not match source order.
To observe actual values, set a breakpoint at Assert.Equal and debug a specific case.

The initial five-test result included a duplicate Fact for 10 C. After removing it,
four Theory cases remained.

### Deliberate Failure and Repair

Temporarily changed `temperatureC < 10` to `temperatureC <= 10`.
The 10 C case failed with Expected: Mild and Actual: Cold; the other three passed.
The test expectation was retained because the business rule had not changed.
Restored `< 10`, reran all tests, and observed four passed with no failures or skips.

## Engineering Best Practices

- Prioritize important rules, boundaries, and previously observed defects.
- Keep tests deterministic using fixed inputs and explicit expected results.
- Read failure details before changing either the implementation or test.
- Rerun the relevant tests after a repair.
- Keep tests independent of execution order.
- A green result validates covered cases; it does not prove all behavior is correct.

## Common Mistakes

- Changing an expected value merely to make a failing test pass.
- Relying on random API data to cover specific boundaries.
- Counting duplicated cases as additional behavioral coverage.
- Treating test runner durations as API latency or throughput measurements.

## Interview Knowledge

### Have I written unit tests?

Yes, in a personal .NET learning project. I used xUnit, AAA, and parameterized
Theory cases to verify service boundaries. I introduced an incorrect comparison,
read the failure, restored the rule, and reran the tests. This does not imply
production testing experience or completed database integration testing.

### Why test both sides of a boundary?

Adjacent cases reveal whether equality belongs to the correct interval and catch
comparison mistakes such as changing less than to less than or equal to.

## What I Implemented

A separate xUnit project and four automated boundary cases.

## What I Learned

How to inspect individual cases, interpret Expected and Actual, and verify that
tests detect a specific regression rather than only showing green results.

## Review Checklist

- [x] Created and referenced the test project.
- [x] Practiced Fact, Theory, InlineData, and AAA.
- [x] Verified 9, 10, 24, and 25 C.
- [x] Observed the deliberate failure and restored all four passing cases.
- [ ] Explain the difference between unit, integration, and load testing without notes.
