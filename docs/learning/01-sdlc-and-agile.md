# Lesson 01 — Software Development Lifecycle and Agile

## Learning Objective

Understand how professional software development is organized before starting implementation.

---

## Software Development Lifecycle

Software Development Lifecycle (SDLC) describes the process used to plan, design, develop, test, deploy, and maintain software.

A simplified lifecycle is:

```text
Requirements
    ↓
Planning
    ↓
Design
    ↓
Development
    ↓
Testing
    ↓
Deployment
    ↓
Maintenance
```

Software development is not only about writing code.

A professional developer should understand why a feature is required, how it should be designed, how it will be tested, and how it will be maintained.

---

## Agile

Agile is a software development approach that focuses on incremental development, continuous feedback, collaboration, and adaptation.

Instead of building the entire system at once, development is divided into smaller iterations.

A simplified Agile workflow is:

```text
Plan
↓
Develop
↓
Test
↓
Review
↓
Improve
↓
Repeat
```

---

## Sprint

A Sprint is a short development cycle used by many Agile teams.

Common Sprint durations include:

- One week
- Two weeks
- Three weeks

A Sprint normally has a specific goal.

Example:

```text
Sprint Goal:
Implement Product Management API
```

---

## Product Backlog

A Product Backlog is a prioritized collection of features, improvements, technical tasks, and other work that may be implemented in the future.

Example:

```text
Product Management
Customer Management
Inventory Management
Order Management
Authentication
Reporting
```

Items in the Product Backlog do not need to be implemented immediately.

---

## User Story

A User Story describes a requirement from the user's perspective.

A common format is:

```text
As a <type of user>,
I want <a capability>,
so that <a benefit>.
```

Example:

```text
As an administrator,
I want to create a product,
so that the product can be sold through the system.
```

---

## Acceptance Criteria

Acceptance Criteria define the conditions that must be satisfied before a feature is considered complete.

Example:

```text
Feature:
Create Product

Acceptance Criteria:

- Product name is required.
- Product price must be greater than zero.
- SKU must be unique.
- A successful request returns HTTP 201.
- Invalid input returns HTTP 400.
```

Acceptance Criteria provide a clear definition of expected behavior.

---

## Repository

A repository is a location used to store project files and their version history.

Git repositories allow developers to track changes to source code and documentation.

---

## Git

Git is a distributed version control system.

It helps developers:

- Track changes
- Review previous versions
- Collaborate with other developers
- Create branches
- Merge changes
- Recover previous versions

---

## README

A README file provides the main introduction and instructions for a software project.

GitHub automatically renders `README.md` files using Markdown.

---

## Markdown

Markdown is a lightweight text formatting language commonly used for software documentation.

Markdown files usually use the `.md` file extension.

---

## SDK

SDK stands for Software Development Kit.

An SDK contains tools required to develop software for a particular platform.

The .NET SDK provides tools for building, running, testing, and managing .NET applications.

---

## IDE

IDE stands for Integrated Development Environment.

An IDE provides tools for writing, debugging, building, and managing software projects.

Visual Studio is an example of an IDE used for .NET development.

---

## Key Takeaway

Professional software development starts before implementation.

Understanding requirements, planning work, documenting decisions, and defining expected behavior are part of backend engineering.
