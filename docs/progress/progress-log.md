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
