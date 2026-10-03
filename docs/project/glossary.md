# Technical Glossary

This document contains technical terms introduced during the project.

---

## Agile

A software development approach based on incremental development, collaboration, feedback, and adaptation.

---

## Product Backlog

A prioritized collection of work that may be implemented in the product.

---

## Sprint

A short development cycle used to complete a defined set of work.

---

## User Story

A description of a requirement written from the user's perspective.

---

## Acceptance Criteria

Conditions that define when a feature behaves as expected and can be considered complete.

---

## SDLC

Software Development Lifecycle.

The process of planning, designing, developing, testing, deploying, and maintaining software.

---

## Git

A distributed version control system used to track changes to files.

---

## Repository

A project location containing files and their version history.

---

## SDK

Software Development Kit.

A collection of development tools used to build applications for a platform.

---

## IDE

Integrated Development Environment.

Software used to write, build, debug, and manage source code.

---

## Markdown

A lightweight text formatting language commonly used for technical documentation.

## Solution and Project

A solution organizes projects. A .NET project contains code and build configuration in a .csproj file.

## Runtime and LTS

A runtime executes applications. LTS means Long Term Support, a release maintenance category.

## API and HTTP

An Application Programming Interface defines how software interacts. HTTP is a request-response protocol used by Web APIs.
GET requests retrieve representations. HTTP 400 means Bad Request; 405 means Method Not Allowed.

## HTTPS and TLS

HTTPS protects HTTP traffic using Transport Layer Security. Redirecting HTTP to HTTPS does not encrypt the first HTTP request.

## Route and Attribute

A route maps a request path to an endpoint. A C# attribute supplies metadata, such as Route or HttpGet.

## JSON and Serialization

JavaScript Object Notation is a data exchange format. Serialization converts objects into a representation for storage or transmission.

## Class, Object, and Property

A class defines a type. An object is an instance. A property exposes a value, which may be stored or computed.

## LINQ and Lambda

Language Integrated Query provides operations on sequences. A lambda is an anonymous function passed as an expression.

## Breakpoint

A debugger setting that pauses execution at a selected location to inspect program state.

## Dependency Injection

DI supplies a component with its dependencies. Constructor injection receives them as constructor parameters.
A DI container manages registered services and their lifetimes.

## Scoped Lifetime

A registered service instance is reused within one scope. ASP.NET Core normally creates one scope for each request.

## OpenAPI

A standard for describing HTTP API operations and data contracts. An OpenAPI document is distinct from an interactive documentation UI.

## Execution Plan and Index

An execution plan describes how a database executes a query. An index is a data structure that can improve selected queries while adding storage and write costs.

## Throughput and Latency Percentiles

Throughput is completed work per unit of time. P95 and P99 latency describe the response-time thresholds covering 95% and 99% of measured requests.
Capacity claims require a defined workload and measurements.

## Unit Test

An automated test of a small unit of behavior. These tests call the classification
service directly without starting an HTTP server or using a database.

## xUnit, Fact, and Theory

xUnit is a .NET testing framework. Fact marks a test without supplied case data.
Theory runs a test with supplied data; InlineData declares individual argument sets.

## Arrange, Act, Assert

AAA organizes a test into preparation, execution, and verification.
An assertion compares observed behavior with the expected business rule.

## Boundary Test and Regression

A boundary test checks values at or near a rule's transition point.
A regression is a change that breaks previously correct behavior.

## Project Reference

A build dependency between projects that lets one use accessible types from the other.
The test project references the API project, not the reverse.

## DTO and Request Contract

Data Transfer Object: a type describing data crossing an application boundary.
A request DTO exposes the fields a client is allowed to submit, separately from a persistence entity.

## SKU

Stock Keeping Unit: a business identifier for an inventory item, distinct from a database primary key.

## Data Annotations

Attributes such as Required, StringLength, and Range that declare validation rules.
Creating an object does not automatically execute those rules.

## Validation Context and Result

ValidationContext describes the object being validated. ValidationResult reports
an error and its associated member names. TryValidateObject performs explicit validation.

## Decimal and Exclusive Bound

Decimal is a base-10 numeric type useful for monetary values. An exclusive lower
bound rejects equality with the minimum. Positive-value validation does not define currency or decimal places.

## nameof

A C# expression that produces a symbol's name as a string, avoiding handwritten property names in assertions.
