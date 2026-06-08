# DEVELOPER GUIDE

## Architecture Overview

The project follows a layered architecture.

```text
src/
├── BankingSystem.Domain
├── BankingSystem.Application
├── BankingSystem.Infrastructure
└── BankingSystem.Console
```

---

## Domain Layer

Responsibilities:

- business entities;
- domain rules;
- repository contracts;
- enumerations.

Main classes:

- BankAccount
- CheckingAccount
- SavingsAccount
- Transaction
- Customer

Interfaces:

- IBankAccountRepository

---

## Application Layer

Responsibilities:

- application services;
- use case implementation;
- DTOs;
- factories;
- persistence contracts.

Main classes:

- AccountService
- QueryService
- AccountPersistenceService
- AccountFactory

Interfaces:

- IDataStore<T>

---

## Infrastructure Layer

Responsibilities:

- repository implementations;
- JSON persistence;
- file operations.

Main classes:

- InMemoryBankAccountRepository
- JsonAccountDataStore

---

## Console Layer

Responsibilities:

- user interaction;
- menu handling;
- input validation;
- output formatting.

Business rules must not be implemented in the console project.

---

## Design Patterns

### Repository Pattern

Used to separate business logic from data storage implementation.

### Factory Pattern

Used to create different account types without modifying application services.

---

## SOLID Principles

### Single Responsibility Principle

Domain entities, services, repositories, and persistence classes each have a single responsibility.

### Open/Closed Principle

New account types can be added through AccountFactory without modifying existing services.

### Dependency Inversion Principle

Application services depend on abstractions such as repositories and persistence contracts.

---

## Running Tests

Run all tests:

```bash
dotnet test
```

Run coverage:

```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
```

---

## Extending the System

Examples of future extensions:

- BusinessAccount
- PremiumAccount
- Database persistence
- Notification service
- Transaction history reports

Most extensions can be implemented without modifying existing business services.

---

## Continuous Integration

GitHub Actions automatically performs:

- restore;
- build;
- test execution;
- coverage generation.

Any failing test causes pipeline failure.
