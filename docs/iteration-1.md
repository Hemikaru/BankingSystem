# Iteration 1 Report

## Реалізовано

На першій ітерації створено архітектурний каркас проєкту Banking System.

Підготовлено:

- структуру solution;
- доменну модель;
- контракти між шарами;
- перший вертикальний зріз;
- базові юніт-тести;
- CI pipeline.

## Артефакти репозиторію

- vision.md
- backlog.md
- class-diagram.md
- sequence-diagram.md
- README.md
- GitHub Actions workflow
- Domain Layer
- Application Layer
- Infrastructure Layer
- Console UI
- Unit Tests

## План розширення для Lab 35

### Сценарій 1

Переказ коштів між рахунками.

### Сценарій 2

Збереження та відновлення даних із JSON-файлів.

### Сценарій 3

Історія транзакцій та LINQ-запити.

## Ризики

- Ускладнення доменної логіки переказів.
- Узгодження файлового сховища з поточними контрактами.
- Можливе розширення моделі транзакцій.

## Підготовка до розширення

Спеціально залишено точки розширення:

- абстрактний клас BankAccount;
- інтерфейс IBankAccountRepository;
- сервісний шар Application;
- окрема модель Transaction;
- окремий шар Infrastructure для persistence.
