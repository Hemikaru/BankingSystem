# Syllabus Coverage

## 1. Основи ООП

### Використано

- класи;
- об'єкти;
- конструктори;
- інкапсуляція;
- наслідування.

### Приклади

- BankAccount
- CheckingAccount
- SavingsAccount
- Customer
- Transaction

---

## 2. Абстракції та поліморфізм

### Використано

- інтерфейси;
- поліморфізм;
- абстракції.

### Приклади

- IBankAccountRepository
- IDataStore<T>
- BankAccount (базовий клас)

---

## 3. Generics, колекції та LINQ

### Generics

- IDataStore<T>

### Колекції

- List<T>
- Dictionary<Guid, BankAccount>

### LINQ

- Where
- OrderByDescending
- Sum
- FirstOrDefault

---

## 4. Обробка помилок і Persistence

### Обробка помилок

- ArgumentException
- InvalidOperationException
- JSON validation

### Persistence

- JSON serialization
- JSON deserialization
- Async Save
- Async Load

---

## 5. SOLID

### Single Responsibility Principle

Сервіси, репозиторії та persistence-класи мають окремі відповідальності.

### Open/Closed Principle

Нові типи рахунків додаються через Factory.

### Dependency Inversion Principle

Сервіси працюють через інтерфейси.

---

## 6. Патерни проєктування

### Repository Pattern

Використано для доступу до даних.

### Factory Pattern

Використано для створення рахунків.

---

## 7. UML

Створено:

- Class Diagram
- Sequence Diagram

---

## 8. Тестування

### Unit Tests

Покрито:

- доменні правила;
- бізнес-логіку;
- Factory Pattern;
- LINQ-запити.

### Integration Tests

Покрито:

- persistence;
- відновлення стану;
- негативні сценарії.

---

## 9. Рефакторинг

Виконано:

- розділення відповідальностей;
- винесення persistence у окремий шар;
- покращення структури сервісів;
- покращення тестованості через інтерфейси.

---

## Додаткові теми

### Реалізовано

- GitHub Actions CI
- JSON Persistence
- Async File I/O
- Coverage Support
- Quality Gate

### Частково реалізовано

- Асинхронність
- Fault Handling

### Не використовувалось

- Observer
- Decorator
- Adapter
- Proxy
- Queue
- Stack
- Retry Policies
