# Product Backlog

## Project

Order & Inventory Management System

## Backlog Items

| ID | Feature | Priority | Status |
|---|---|---|---|
| PB-001 | Product Management | High | In Progress |
| PB-002 | Customer Management | Medium | Planned |
| PB-003 | Inventory Management | High | Planned |
| PB-004 | Order Management | High | Planned |
| PB-005 | Authentication and Authorization | High | Planned |
| PB-006 | Reporting | Medium | Planned |

## PB-001 - Create Product

### User Story

As an administrator, I want to create a product so that it can be managed in the inventory system.

### Acceptance Criteria

- [x] Define a request DTO containing Name, Sku, and Price; exclude server-generated identifiers.
- [x] Reject empty or whitespace-only names and SKUs during DTO validation.
- [x] Limit Name to 200 and Sku to 50 characters using the current .NET string validation semantics.
- [x] Require Price greater than zero during DTO validation.
- [ ] Return HTTP 400 for invalid request input through the API.
- [ ] Enforce SKU uniqueness, including concurrent creation attempts, and return HTTP 409 for duplicates.
- [ ] Persist a valid product and return HTTP 201 with its representation and a retrievable Location URL.
- [ ] Enforce administrator access after authentication and authorization are implemented.

The checked items describe DTO preparation, not completed API behavior.
Currency, price scale and business maximum, SKU case sensitivity and normalization,
and database design still require decisions before persistence is implemented.
The current DTO accepts any positive decimal, including 0.001.

## Status Definitions

### Planned

The item is planned but development has not started.

### In Progress

The item is currently being developed.

### Completed

The item has been implemented, tested, and documented.
