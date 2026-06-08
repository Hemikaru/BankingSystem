# DEMO SCENARIO

## Duration

3–5 minutes

---

## Step 1. Project Overview

Briefly present:

- project goal;
- architecture;
- repository structure.

Show:

```text
Domain
Application
Infrastructure
Console
Tests
```

---

## Step 2. Create Accounts

Create two accounts:

- ACC-001
- ACC-002

Explain the use of Factory Pattern.

---

## Step 3. Deposit Funds

Deposit:

```text
ACC-001 -> 1000
```

Show updated balance.

---

## Step 4. Transfer Funds

Transfer:

```text
ACC-001 -> ACC-002
Amount: 300
```

Demonstrate:

- balance update;
- business rule validation.

---

## Step 5. Negative Scenario

Attempt:

```text
Transfer 5000
```

or

```text
Withdraw 5000
```

Show:

```text
Insufficient funds
```

Explain fault handling.

---

## Step 6. Save State

Select:

```text
Save accounts
```

Show generated:

```text
accounts.json
```

---

## Step 7. Restore State

Restart application.

Select:

```text
Load accounts
```

Verify balances remain unchanged.

---

## Step 8. Analytics

Demonstrate:

- total balance;
- richest account.

Explain LINQ queries.

---

## Step 9. Testing and CI

Show:

```text
dotnet test
```

and GitHub Actions.

Explain quality gate.

---

## Step 10. Conclusion

Summarize:

- implemented functionality;
- architecture;
- testing;
- persistence;
- future improvements.
