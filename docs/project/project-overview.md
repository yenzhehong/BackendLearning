# Project Overview

## Project Name

Order & Inventory Management System

## Project Purpose

The purpose of this project is to build a realistic backend system while learning professional .NET backend development practices.

The system will gradually support product management, customer management, inventory management, order processing, authentication, reporting, and other backend capabilities.

## Learning Objective

The main objective is not only to build a working application.

The project is intended to develop an understanding of:

- Backend architecture
- API design
- Database design
- Maintainable code
- Security
- Performance
- Testing
- Documentation
- Software development workflows
- Engineering trade-offs

## Development Approach

The project will be developed incrementally using Agile practices.

Features will be introduced only when the required concepts have been studied and understood.

## Current Status

A .NET 10 controller-based API has been created and exercised locally.
The weather sample uses a scoped service to classify temperatures.
An xUnit project verifies four boundary cases for the service. A deliberate boundary
error was detected by a failing test, then corrected and verified.
Product Management has started with a request DTO and twelve validation test cases.
Product endpoints, persistence, SKU uniqueness enforcement, and authentication are not implemented.

## Engineering Standards

- Keep HTTP handling and business rules separate when this improves clarity and testing.
- Design database constraints and transactions to protect business correctness.
- Design indexes around actual queries and verify their effect with execution plans.
- Use bounded results, pagination, and asynchronous I/O where appropriate.
- Measure latency percentiles, throughput, errors, and resource usage under defined workloads.
- Introduce caching and distributed infrastructure when requirements and measurements justify them.
- Treat high traffic capacity as a goal to validate, not a property guaranteed by a template.
- Review changes before committing; push only when explicitly requested.
