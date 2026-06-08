# Product Backlog

## Iteration 1 (Lab 34) - Baseline ✅

### Реалізовано

- Створення рахунку
- Поповнення рахунку
- Перегляд балансу
- Доменна модель
- In-Memory Repository
- Unit Tests
- CI Pipeline
- UML Documentation

---

## Iteration 2 (Lab 35) - Business Logic & Persistence

### High Priority

- Зняття коштів з рахунку
- Переказ між рахунками
- JSON Persistence
- Відновлення стану з файлу
- Factory Pattern
- LINQ-запити
- Розширене консольне меню

### Business Rules

- Неможливо поповнити рахунок на суму ≤ 0
- Неможливо зняти суму ≤ 0
- Неможливо зняти більше коштів, ніж є на балансі
- Неможливо переказати кошти самому собі
- Неможливо переказати суму ≤ 0

### Queries & Analytics

- Пошук рахунку за номером
- Сортування рахунків за балансом
- Отримання рахунків із позитивним балансом
- Розрахунок загальної суми коштів у системі

### Persistence

- SaveAsync()
- LoadAsync()
- Обробка пошкодженого JSON
- Обробка відсутнього файлу

---

## Iteration 3 (Lab 36) - Quality Gate & Testing

### High Priority

- Integration Tests
- Coverage Report
- Fault Handling
- Quality Gate
- Test Strategy
- Test Matrix

### Medium Priority

- Тестування файлового сховища
- Тестування бізнес-правил
- Негативні сценарії

---

## Iteration 4 (Lab 37) - Release

### High Priority

- USER_GUIDE
- DEVELOPER_GUIDE
- CHANGELOG
- DEMO
- FINAL_REPORT

### Medium Priority

- Рефакторинг
- Release Preparation
- Documentation Review

### Possible Extensions

- BusinessAccount
- XML Export
- Observer Notifications
- Transaction Analytics
