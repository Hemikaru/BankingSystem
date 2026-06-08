# TESTING

## Overview

Проєкт використовує xUnit для автоматизованого тестування бізнес-логіки та інтеграції між компонентами.

---

## Running Tests

Запуск усіх тестів:

```bash
dotnet test
```

---

## Running Coverage

Встановлення coverlet:

```bash
dotnet add tests/BankingSystem.Tests package coverlet.msbuild
```

Генерація coverage:

```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
```

---

## Coverage Report

Generate coverage:

```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
```

## Unit Tests

Перевіряють:

- доменні інваріанти;
- бізнес-правила;
- Factory Pattern;
- QueryService;
- негативні сценарії.

---

## Integration Tests

Перевіряють:

- JSON persistence;
- Save / Load цикл;
- роботу після відновлення стану;
- реакцію на пошкоджені дані;
- роботу з відсутніми файлами.

---

## Covered Business Rules

- Deposit amount > 0
- Withdraw amount > 0
- No negative balance
- Transfer amount > 0
- Cannot transfer to same account

---

## Quality Gate

Перед merge повинні проходити:

- dotnet restore
- dotnet build
- dotnet test

Усі тести повинні бути успішними.
