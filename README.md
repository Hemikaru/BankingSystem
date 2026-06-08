# Banking System

Навчальний проєкт банківської системи, створений у рамках курсу ООП.

## Реалізована функціональність

- Створення банківського рахунку
- Поповнення рахунку
- Перегляд балансу

## Архітектура

Проєкт поділений на шари:

- Domain
- Application
- Infrastructure
- Console

## Запуск проєкту

```bash
dotnet run --project src/BankingSystem.Console
```

## Запуск тестів

```bash
dotnet test
```

## Структура рішення

```text
src/
├── BankingSystem.Domain
├── BankingSystem.Application
├── BankingSystem.Infrastructure
└── BankingSystem.Console

tests/
└── BankingSystem.Tests

docs/
├── vision.md
├── backlog.md
├── class-diagram.md
├── sequence-diagram.md
└── iteration-1.md
```
