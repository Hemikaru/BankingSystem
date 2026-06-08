# USER GUIDE

## Overview

Banking System is a console application that allows users to manage bank accounts, perform financial operations, and persist account data between application runs.

---

## Starting the Application

Run the application:

```bash
dotnet run --project src/BankingSystem.Console
```

After startup, the main menu will be displayed.

---

## Main Menu

Available operations:

1. Create account
2. Deposit money
3. Withdraw money
4. Transfer money
5. Show total balance
6. Show richest account
7. Save accounts
8. Load accounts
9. Exit

---

## Creating an Account

1. Select **Create account**.
2. Enter an account number.
3. Select account type:
   - Checking
   - Savings

4. The system creates the account and displays its identifier.

---

## Depositing Money

1. Select **Deposit**.
2. Enter account identifier.
3. Enter deposit amount.
4. The balance will be updated.

Restrictions:

- amount must be greater than zero.

---

## Withdrawing Money

1. Select **Withdraw**.
2. Enter account identifier.
3. Enter amount.

Restrictions:

- amount must be greater than zero;
- account must contain sufficient funds.

---

## Transferring Money

1. Select **Transfer**.
2. Enter source account identifier.
3. Enter target account identifier.
4. Enter amount.

Restrictions:

- accounts must be different;
- source account must contain sufficient funds.

---

## Saving Data

Select **Save accounts**.

All account data will be stored in:

```text
accounts.json
```

---

## Loading Data

Select **Load accounts**.

Previously saved account information will be restored.

---

## Error Messages

Examples:

- Account not found
- Insufficient funds
- Amount must be greater than zero
- Data file is corrupted

The system prevents invalid operations and displays appropriate error messages.
