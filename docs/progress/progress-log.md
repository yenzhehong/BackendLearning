# Development and Learning Progress Log

## 2026-10-02

### Completed

- Defined the project purpose.
- Introduced the Software Development Lifecycle.
- Introduced Agile development.
- Learned about Sprints.
- Learned about Product Backlogs.
- Learned about User Stories.
- Learned about Acceptance Criteria.
- Created the initial documentation structure.

### New Terminology

- SDLC
- Agile
- Sprint
- Product Backlog
- User Story
- Acceptance Criteria
- Repository
- Git
- README
- Markdown
- SDK
- IDE

### Current Project Stage

API fundamentals and dependency injection practice.

### Next Step

Review the application and documentation changes before the next commit.

### Environment and API Practice Completed

- Confirmed SDKs 8.0.422 and 10.0.401 and ASP.NET Core runtimes 8.0.28 and 10.0.12.
- Confirmed Visual Studio Community 2026 version 18.10.3 and its Web development workload.
- Created the OrderInventory solution and OrderInventory.Api project targeting .NET 10.
- Started the HTTPS profile and received JSON from GET /weatherforecast.
- Observed HTTP 200 and application/json in the browser's Network panel.
- Practiced routing changes, breakpoints, and inspecting the forecasts array.
- Matched debugger object values to the JSON response for the same request.
- Created WeatherSummaryService and registered it with AddScoped.
- Injected the service through the controller constructor.
- Confirmed sample results: 23 C is Mild; 48 C is Hot; negative temperatures are Cold.
- Saved Lessons 02 and 03 and updated the project documentation.

### Verification Limits

- Runtime observations above were supplied through learner screenshots.
- Boundary values 10 C and 25 C have not yet been verified by automated tests.
- No load test has been performed; no throughput or latency target has been established.
- Initial documentation was committed and pushed earlier; the new application and notes await review.

## 2026-10-03

### Completed

- Created OrderInventory.Api.Tests targeting .NET 10 with xUnit.
- Added a project reference to OrderInventory.Api.
- Wrote a Fact test for 10 C returning Mild, then replaced it with a Theory.
- Added InlineData cases for 9, 10, 24, and 25 C.
- Viewed case parameters in Test Explorer and removed the duplicate Fact test.
- Temporarily changed the rule from less than 10 to less than or equal to 10.
- Observed 3 passed and 1 failed, with Expected: Mild and Actual: Cold for 10 C.
- Restored the original rule and observed 4 passed, 0 failed, and 0 skipped.
- Saved Lesson 04 and updated the glossary, README, project status, and Lesson 03 checklist.

### Current Project Stage

Unit testing fundamentals and boundary regression verification.

### Verification Limits

- Earlier application and documentation changes were committed as 6229edf and the learner reported a successful push.
- Visual Studio test results were supplied through learner screenshots.
- Independently reran dotnet test with --no-restore: 4 passed, 0 failed, 0 skipped.
- These unit tests do not exercise HTTP routing, DI registration, database behavior, concurrency, or load capacity.
- Test runner durations are not performance benchmarks.

### Next Step

Review the test project and documentation changes before committing.

## 2026-10-04

### Completed

- Defined initial Create Product requirements and HTTP acceptance criteria.
- Created CreateProductRequest under Contracts/Products with Name, Sku, and decimal Price.
- Added Required, StringLength, and decimal Range validation attributes.
- Used an exclusive zero minimum and invariant-culture range-limit parsing.
- Wrote twelve DTO validation cases, including blank fields, length boundaries, and price checks.
- Observed 16 passed, 0 failed, and 0 skipped in the learner's Test Explorer screenshot.
- Independently reran dotnet test with --no-restore: 16 passed, 0 failed, and 0 skipped.
- Saved Lesson 05, updated project records, and marked Product Management In Progress.

### Current Project Stage

Create-product contract and input validation preparation.

### Verification Limits

- The sixteen cases consist of twelve DTO tests and four weather service tests.
- DTO tests call the validation API directly; they do not verify HTTP 400 responses.
- SKU uniqueness, persistence, administrator access, concurrency, and load capacity remain unimplemented or unverified.
- Currency, price precision and scale, and business maximum are undecided; 0.001 currently passes.
- Null inputs and additional Unicode or serialization edge cases are not covered by these twelve DTO cases.

### Next Step

Review and commit the DTO, tests, and notes before continuing to a product endpoint.
